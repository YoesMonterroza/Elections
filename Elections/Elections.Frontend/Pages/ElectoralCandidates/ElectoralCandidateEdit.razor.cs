using Blazored.Modal.Services;
using Blazored.Modal;
using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Frontend.Repositories;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Elections.Frontend.Pages.VotingStations;

namespace Elections.Frontend.Pages.ElectoralCandidates
{
    public partial class ElectoralCandidateEdit
    {
        [Parameter] public int Id { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; } = default!;


        private ElectoralCandidateForm? electoralCandidateForm;
        private ElectoralCandidate electoralCandidate = new();
        private readonly String ELECTORAL_CANDIDATE_PATH = "api/ElectoralCandidateRegister";
       


        protected override async Task OnInitializedAsync()
        {
            var responseHttp = await Repository.GetAsync<ElectoralCandidate>(string.Concat(ELECTORAL_CANDIDATE_PATH, $"/{Id}"));
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("api/ElectoralCandidateRegister/full");
                }
                else
                {
                    var messageError = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", messageError, SweetAlertIcon.Error);
                }
            }
            else
            {
                electoralCandidate = responseHttp.Response;
            }
        }

        private async Task EditAsyncCandidate()
        {

            var responseHttp = await Repository.PutAsync(ELECTORAL_CANDIDATE_PATH, electoralCandidate);
            if (responseHttp.Error)
            {
                var mensajeError = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", mensajeError, SweetAlertIcon.Error);
                return;
            }
            await BlazoredModal.CloseAsync(ModalResult.Ok());
            Return();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.Center,
                ShowConfirmButton = true,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Cambios guardados con éxito.");
        }

        private void Return()
        {
            electoralCandidateForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("ElectoralCandidateRegister/full");
        } 

    }
}