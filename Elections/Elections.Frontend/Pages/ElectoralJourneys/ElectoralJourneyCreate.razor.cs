using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Frontend.Pages.ElectoralPositions;
using Elections.Frontend.Repositories;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace Elections.Frontend.Pages.ElectoralJourneys
{
    [Authorize(Roles = "Admin")]
    public partial class ElectoralJourneyCreate
    {
        private ElectoralJourney electoralJourney = new();
        private ElectoralJourneyForm? electoralJourneyForm;
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        private readonly String ELECTORAL_JOURNEY_PATH = "api/electoralJourneys";
        private async Task CreateAsync()
        {
            var responseHttp = await Repository.PostAsync(ELECTORAL_JOURNEY_PATH, electoralJourney);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message);
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
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro creado con éxito.");
        }
        private void Return()
        {
            electoralJourneyForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("electoralJourneys");
        }
    }
}
