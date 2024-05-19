using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Frontend.Repositories;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Blazored.Modal.Services;
using Blazored.Modal;
using Elections.Frontend.Pages.VotingStations;

namespace Elections.Frontend.Pages.ElectoralCandidates
{
    public partial class ElectoralCandidateIndex
    {
        private int totalPages;
        private int currentPage = 1;
         

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;


        [Parameter, SupplyParameterFromQuery] public string Page { get; set; } = string.Empty;
        [Parameter, SupplyParameterFromQuery] public string Filter { get; set; } = string.Empty;
        [Parameter, SupplyParameterFromQuery] public int RecordsNumber { get; set; } = 10;
        [CascadingParameter] IModalService Modal { get; set; } = default!;


        public List<ElectoralCandidate>? ElectoralCandidates { get; set; }
        private readonly String ELECTORAL_CANDIDATE_PATH = "api/ElectoralCandidateRegister/full";
        private readonly String ELECTORAL_CANDIDATE_PATH_MAIN= "api/ElectoralCandidateRegister";


        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
        }

        private async Task ShowModalAsync(int id = 0, bool isEdit = false)
        {
            IModalReference modalReference;
            if (isEdit)
            {
                modalReference = Modal.Show<ElectoralCandidateCreate>(new ModalParameters().Add("Id", id));
            }
            else
            {
                modalReference = Modal.Show<ElectoralCandidateCreate>();
            }
            var result = await modalReference.Result;
            if (result.Confirmed)
            {
                await LoadAsync();
            }
        }

        //LOAD
        private async Task LoadAsync(int page = 1)
        {
            if (!string.IsNullOrWhiteSpace(Page))
            {
                page = Convert.ToInt32(Page);
            }

            var ok = await LoadListAsync(page);
            if (ok)
            {
                await LoadPagesAsync();
            }
        }

        private async Task<bool> LoadListAsync(int page)
        {
            validateRecordsNumber(RecordsNumber);
            var url = string.Concat(ELECTORAL_CANDIDATE_PATH, $"?page={page}", $"&recordsnumber={RecordsNumber}");
            if (!string.IsNullOrEmpty(Filter))
            {
                url += $"&filter={Filter}";
            }

            var responseHttp = await Repository.GetAsync<List<ElectoralCandidate>>(url);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return false;
            }
            ElectoralCandidates = responseHttp.Response.Where(x=>x.Enabled == true).ToList();
            return true;
        }

        private async Task LoadPagesAsync()
        {
            var url = string.Concat(ELECTORAL_CANDIDATE_PATH_MAIN, "/totalPages", $"?recordsnumber={RecordsNumber}");
            if (!string.IsNullOrEmpty(Filter))
            {
                url += $"&filter={Filter}";
            }

            var responseHttp = await Repository.GetAsync<int>(url);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            totalPages = responseHttp.Response;
        }

        private void validateRecordsNumber(int recordsnumber)
        {
            if (recordsnumber == 0)
            {
                RecordsNumber = 10;
            }
        }

        private async Task ApplyFilterAsync(string filter)
        {
            Filter = filter;
            int page = 1;
            await LoadAsync(page);
            await SelectedPageAsync(page);
        }

        private async Task SelectedPageAsync(int page)
        {
            currentPage = page;
            await LoadAsync(page);
        }

        private async Task SelectedRecordsNumberAsync(int recordsnumber)
        {
            RecordsNumber = recordsnumber;
            int page = 1;
            await LoadAsync(page);
            await SelectedPageAsync(page);
        }

        private async Task DeleteAsync(ElectoralCandidate electoralCandidate)
        {
            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmación",
                Text = $"¿Esta seguro que quieres borrar el Candidato: {electoralCandidate.Document}?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true
            });
            var confirm = string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }
            //var responseHTTP = await Repository.DeleteAsync(string.Concat(ELECTORAL_CANDIDATE_PATH_MAIN, $"/{electoralCandidate.Id}"));

            electoralCandidate.Enabled = false;
            var responseHTTP = await Repository.PutAsync(ELECTORAL_CANDIDATE_PATH_MAIN, electoralCandidate);
            if (responseHTTP.Error)
            {
                if (responseHTTP.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    var mensajeError = await responseHTTP.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", mensajeError, SweetAlertIcon.Error);
                }
                return;
            }

            await LoadAsync();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.Center,
                ShowConfirmButton = true,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro borrado con éxito.");
        }
    }
}