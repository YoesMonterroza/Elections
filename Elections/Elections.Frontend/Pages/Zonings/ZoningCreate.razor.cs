using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Frontend.Repositories;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace Elections.Frontend.Pages.Zonings
{
    [Authorize(Roles = "Admin")]
    public partial class ZoningCreate
    {
        private Zoning zoning = new();
        private ZoningForm? zoningForm;

        [Parameter] public int VotingStationId { get; set; }
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        private readonly String ZONING_PATH = "api/zonings";

        private async Task CreateAsync()
        {
            zoning.VotingStationId = VotingStationId;
            var responseHttp = await Repository.PostAsync(ZONING_PATH, zoning);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
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
            zoningForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo($"/votingstations/details/{VotingStationId}");
        }

    }
}
