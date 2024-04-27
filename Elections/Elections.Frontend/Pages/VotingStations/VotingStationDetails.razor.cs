using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Frontend.Repositories;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.Metrics;
using System.Net;

namespace Elections.Frontend.Pages.VotingStations
{
    public partial class VotingStationDetails
    {
        private VotingStation? votingStation;
        private List<Zoning>? zonings;
        private int currentPage = 1;
        private int totalPages;


        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;

        [Parameter, SupplyParameterFromQuery] public string Page { get; set; } = string.Empty;
        [Parameter, SupplyParameterFromQuery] public string Filter { get; set; } = string.Empty;
        [Parameter, SupplyParameterFromQuery] public int RecordsNumber { get; set; } = 10;


        [Parameter]
        public int VotingStationId { get; set; }

        private readonly String VOTING_STATION_PATH = "api/votingstations";
        private readonly String ZONING_PATH = "api/zonings";

        protected override async Task OnInitializedAsync()
        {            
            await LoadAsync();
        }

        private async Task DeleteAsync(Zoning zoning)
        {
            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmación",
                Text = $"¿Realmente deseas eliminar la mesa de votación? {zoning.ZoningNumber}",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                CancelButtonText = "No",
                ConfirmButtonText = "Si"
            });

            var confirm = string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }
            var url = string.Concat(ZONING_PATH, $"/{zoning.Id}");
            var responseHttp = await Repository.DeleteAsync(url);
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode != HttpStatusCode.NotFound)
                {
                    var message = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                    return;
                }
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

        private async Task SelectedPageAsync(int page)
        {
            if (!string.IsNullOrWhiteSpace(Page))
            {
                page = Convert.ToInt32(Page);
            }

            currentPage = page;
            await LoadAsync(page);
        }

        private async Task LoadAsync(int page = 1)
        {
            var ok = await LoadVotingStationAsync();
            if (ok)
            {
                ok = await LoadZoningsAsync(page);
                if (ok)
                {
                    await LoadPagesAsync();
                }
            }
        }

        private async Task LoadPagesAsync()
        {
            validateRecordsNumber(RecordsNumber);
            var url = string.Concat(ZONING_PATH, $"/totalPages?id={VotingStationId}", $"&recordsnumber={RecordsNumber}");
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

        private async Task<bool> LoadZoningsAsync(int page)
        {
            validateRecordsNumber(RecordsNumber);
            var url = string.Concat(ZONING_PATH, $"?id={VotingStationId}&page={page}", $"&recordsnumber={RecordsNumber}");
            if (!string.IsNullOrEmpty(Filter))
            {
                url += $"&filter={Filter}";
            }

            var responseHttp = await Repository.GetAsync<List<Zoning>>(url);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return false;
            }
            zonings = responseHttp.Response;
            return true;
        }

        private async Task<bool> LoadVotingStationAsync()
        {
            var responseHttp = await Repository.GetAsync<VotingStation>(string.Concat(VOTING_STATION_PATH, $"/{VotingStationId}"));
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/votingstations");
                    return false;
                }

                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return false;
            }
            votingStation = responseHttp.Response;
            return true;
        }

        private async Task ApplyFilterAsync(string filter)
        {
            Filter = filter;
            int page = 1;
            await LoadAsync(page);
            await SelectedPageAsync(page);
        }

        private async Task SelectedRecordsNumberAsync(int recordsnumber)
        {
            RecordsNumber = recordsnumber;
            int page = 1;
            await LoadAsync(page);
            await SelectedPageAsync(page);
        }

        private void validateRecordsNumber(int recordsnumber)
        {
            if (recordsnumber == 0)
            {
                RecordsNumber = 10;
            }
        }


    }
}
