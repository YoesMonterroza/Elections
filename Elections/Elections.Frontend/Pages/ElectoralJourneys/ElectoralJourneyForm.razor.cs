using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Authorization;

namespace Elections.Frontend.Pages.ElectoralJourneys
{
    [Authorize(Roles = "Admin")]
    public partial class ElectoralJourneyForm
    {
        private EditContext editContext = null!;
        public bool FormPostedSuccessfully { get; set; } = false;

        [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }

        [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }

        [EditorRequired, Parameter] public ElectoralJourney ElectoralJourney { get; set; } = null!;

        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        protected override void OnInitialized()
        {
            editContext = new(ElectoralJourney);
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
