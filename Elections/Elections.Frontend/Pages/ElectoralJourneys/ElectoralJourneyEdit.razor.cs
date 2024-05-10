using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Frontend.Pages.ElectoralPositions;
using Elections.Frontend.Repositories;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace Elections.Frontend.Pages.ElectoralJourneys
{
    [Authorize(Roles = "Admin")]
    public partial class ElectoralJourneyEdit
    {
        private ElectoralJourney? electoralJourney;
        private ElectoralJourneyForm? electoralJourneyForm;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Parameter] public int Id { get; set; }

        private readonly String VOTING_STATION_PATH = "api/electoralJourneys";
        protected override async Task OnInitializedAsync()
        {
            var responseHttp = await Repository.GetAsync<ElectoralJourney>(string.Concat(VOTING_STATION_PATH, $"/{Id}"));
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("electoralJourneys");
                }
                else
                {
                    var messageError = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", messageError, SweetAlertIcon.Error);
                }
            }
            else
            {
                electoralJourney = responseHttp.Response;
            }
        }
        private async Task EditAsync()
        {
            var responseHttp = await Repository.PutAsync(VOTING_STATION_PATH, electoralJourney);
            if (responseHttp.Error)
            {
                var mensajeError = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", mensajeError, SweetAlertIcon.Error);
                return;
            }
            Return();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Cambios guardados con éxito.");
        }
        private void Return()
        {
            electoralJourneyForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("electoralJourneys");
        }

        }
    }
