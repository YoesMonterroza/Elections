using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using Elections.Shared.Entities;
using Elections.Frontend.Repositories;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authorization;

namespace Elections.Frontend.Pages.ElectoralCandidates
{
    public partial class ElectoralCandidateForm
    {
        private EditContext editContext = null!;
         
        public bool FormPostedSuccessfully { get; set; } = false;
        [Inject] private IRepository Repository { get; set; } = null!;
        [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }       
        [EditorRequired, Parameter] public ElectoralCandidate electoralCandidate { get; set; } = null!;
         
        private List<ElectoralJourney> electoralJourneys = new();
        private List<ElectoralPosition> ElectoralPositions = new();
        private List<User> Candidates = new();

        private int countryselected;
        private int electoralJourneyIdselected;
        private int ElectoralPositionIdselected;
        private string Candidateselected;


        //METHOD
        protected override void OnInitialized()
        {
            editContext = new(electoralCandidate);
        }

        protected override async Task OnInitializedAsync()
        {            
            await LoadElectoralJourneysAsync();
            await LoadElectoralPositionsAsync();
            await LoadCandidatesAsync();
        }

        private async Task LoadElectoralJourneysAsync()
        {
            var responseHttp = await Repository.GetAsync<List<ElectoralJourney>>("/api/ElectoralJourneys/full");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            electoralJourneys = responseHttp.Response;
        }

        private async Task LoadElectoralPositionsAsync()
        {
            var responseHttp = await Repository.GetAsync<List<ElectoralPosition>>("/api/ElectoralPositions/full");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            ElectoralPositions = responseHttp.Response;
        }

        private async Task LoadCandidatesAsync()
        {
            var responseHttp = await Repository.GetAsync<List<User>>("/api/Accounts/GetAllUser");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            Candidates = responseHttp.Response;
        }

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            var formWasEdited = editContext.IsModified();
            if (!formWasEdited || FormPostedSuccessfully)
            {
                return;
            }
            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmación",
                Text = "¿Deseas abandonar la página y perder los cambios?",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true
            });
            var confirm = !string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }
            context.PreventNavigation();
        }
         
    }
}