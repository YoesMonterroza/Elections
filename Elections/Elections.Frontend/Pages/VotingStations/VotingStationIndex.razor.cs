﻿using Elections.Frontend.Repositories;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Components;
using CurrieTechnologies.Razor.SweetAlert2;
using System.Diagnostics.Metrics;

namespace Elections.Frontend.Pages.VotingStations
{
    partial class VotingStationIndex
    {
        public List<VotingStation>? VotingStations { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        private readonly String VOTING_STATION_PATH = "api/votingstation";
        protected override async Task OnInitializedAsync()
        {
            await LoadAsync();
        }

        private async Task DeleteAsync(VotingStation votingStation)
        {
            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmación",
                Text = $"¿Esta seguro que quieres borrar el puesto de votación: {votingStation.Name}?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true
            });
            var confirm = string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }            
            var responseHTTP = await Repository.DeleteAsync(string.Concat(VOTING_STATION_PATH, $"/{votingStation.Id}"));
            if (responseHTTP.Error)
            {
                if (responseHTTP.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    NavigationManager.NavigateTo("/");
                }
                else
                {
                    var mensajeError = await responseHTTP.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", mensajeError, SweetAlertIcon.Error);
                }
                return;
            }
            await LoadAsync();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro borrado con éxito.");
        }

        private async Task LoadAsync()
        {
            var responseHppt = await Repository.GetAsync<List<VotingStation>>(VOTING_STATION_PATH);
            if (responseHppt.Error)
            {
                var message = await responseHppt.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            VotingStations = responseHppt.Response!;
        }
    }
}
