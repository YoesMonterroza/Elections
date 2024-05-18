using Blazored.Modal;
using Blazored.Modal.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Frontend.Repositories;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace Elections.Frontend.Pages.Zonings
{
    [Authorize(Roles = "Admin")]
    public partial class ZoningEdit
    {
        private Zoning? zoning;
        private ZoningForm? zoningForm;

        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        [Parameter] public int ZoningId { get; set; }
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; } = default!;

        private readonly String ZONING_PATH = "api/zonings";

        protected override async Task OnParametersSetAsync()
        {
            var responseHttp = await Repository.GetAsync<Zoning>(string.Concat(ZONING_PATH, $"/{ZoningId}"));
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    Return();
                }
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            zoning = responseHttp.Response;
        }

        private async Task SaveAsync()
        {
            var responseHttp = await Repository.PutAsync(ZONING_PATH, zoning);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            await BlazoredModal.CloseAsync(ModalResult.Ok());

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
            zoningForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo($"/votingstations/details/{zoning!.VotingStationId}");
        }

    }
}
