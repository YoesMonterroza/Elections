﻿using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Elections.Frontend.Pages.ElectoralPositions
{
    public partial class ElectoralPositionForm
    {
        private EditContext editContext = null!;
        public bool FormPostedSuccessfully { get; set; } = false;

        [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }

        [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }

        [EditorRequired, Parameter] public ElectoralPosition ElectoralPosition { get; set; } = null!;

        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        protected override void OnInitialized()
        {
            editContext = new(ElectoralPosition);
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