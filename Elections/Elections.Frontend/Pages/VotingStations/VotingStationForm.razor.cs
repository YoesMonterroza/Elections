using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using Elections.Shared.Entities;
using Elections.Frontend.Repositories;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authorization;

namespace Elections.Frontend.Pages.VotingStations
{
    [Authorize(Roles = "Admin")]
    public partial class VotingStationForm
    {
        public bool FormPostedSuccessfully { get; set; } = false;

        [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }

        [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }

        [EditorRequired, Parameter] public VotingStation VotingStation { get; set; } = null!;

        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;

        private EditContext editContext = null!;
        private List<City> cities = new();
        private List<State> states = new();
        private List<Country> countries = new();
        private int countryselected;
        private int stateselected;
        private int cityselected;

        protected override void OnInitialized()
        {
            editContext = new(VotingStation);
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadCountriesAsync();
            if(VotingStation.City!=null)
            {
                countryselected = VotingStation.City!.State!.Country!.Id;
                stateselected = VotingStation.City!.State!.Id;
                cityselected = VotingStation.City!.Id;
                await LoadStatesAsync(countryselected);
                await LoadCitiesAsync(stateselected);
            }
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

        private async Task LoadCountriesAsync()
        {
            var responseHttp = await Repository.GetAsync<List<Country>>("/api/countries/combo");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            countries = responseHttp.Response;
        }

        private async Task CountryChangedAsync(ChangeEventArgs e)
        {
            var selectedCountry = Convert.ToInt32(e.Value!);
            states = null;
            cities = null;
            VotingStation.CityId = 0;
            await LoadStatesAsync(selectedCountry);
        }

        private async Task LoadStatesAsync(int countryId)
        {
            var responseHttp = await Repository.GetAsync<List<State>>($"/api/states/combo/{countryId}");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            states = responseHttp.Response;
        }

        private async Task StateChangedAsync(ChangeEventArgs e)
        {
            var selectedState = Convert.ToInt32(e.Value!);
            cities = null;
            VotingStation.CityId = 0;
            await LoadCitiesAsync(selectedState);
        }

        private async Task LoadCitiesAsync(int stateId)
        {
            var responseHttp = await Repository.GetAsync<List<City>>($"/api/cities/combo/{stateId}");
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            cities = responseHttp.Response;
        }
    }
}
