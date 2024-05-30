using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Frontend.Repositories;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;

namespace Elections.Frontend.Pages.Votes
{
    public partial class VoteForm
    {
        
        [Inject] private IRepository Repository { get; set; } = null!;
        [EditorRequired, Parameter] public Vote vote { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }
        public bool FormPostedSuccessfully { get; set; } = false;
        private List<ElectoralJourney> electoralJourneys = new();
        private EditContext editContext = null!;
        private int electoralJourneyIdselected;

        //METHOD
        protected override void OnInitialized()
        {
            editContext = new(vote);
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadElectoralJourneysAsync();
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

        private async Task AddVoteToCandidate(int CandidateId)
        {

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