using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Frontend.Repositories;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace Elections.Frontend.Pages.VotingStations
{
    [Authorize(Roles = "Admin")]
    public partial class VotingStationEdit
    {
        private VotingStation? votingStation;
        private VotingStationForm? votingStationForm;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Parameter] public int Id { get; set; }

        private readonly String VOTING_STATION_PATH = "api/votingstations";
        protected override async Task OnInitializedAsync()
        {            
            var responseHttp = await Repository.GetAsync<VotingStation>(string.Concat(VOTING_STATION_PATH, $"/{Id}"));
            if (responseHttp.Error)
            {
                if (responseHttp.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("votingstations");
                }
                else
                {
                    var messageError = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", messageError, SweetAlertIcon.Error);
                }
            }
            else
            {
                votingStation = responseHttp.Response;
            }
        }
       private async Task EditAsync()
        {

            var responseHttp = await Repository.PutAsync(VOTING_STATION_PATH, prepareVotingStation(votingStation!));
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
                Position = SweetAlertPosition.Center,
                ShowConfirmButton = true,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Cambios guardados con éxito.");
        }
        
        private void Return()
        {
            votingStationForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("votingstations");
        }
        private VotingStation prepareVotingStation(VotingStation votingStation)
        {
            votingStation.City = null;
            return votingStation;
        }

    }
}
