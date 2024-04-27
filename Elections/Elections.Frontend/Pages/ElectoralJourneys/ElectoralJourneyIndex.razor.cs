using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Frontend.Repositories;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace Elections.Frontend.Pages.ElectoralJourneys
{
    public partial class ElectoralJourneyIndex
    {

        [Inject] private IRepository Repository { get; set; } = null!;
        public List<ElectoralJourney>? ElectoralJourneys { get; set; }
        private int currentPage = 1;
        private int totalPages;

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        [Parameter, SupplyParameterFromQuery] public string Page { get; set; } = string.Empty;
        [Parameter, SupplyParameterFromQuery] public string Filter { get; set; } = string.Empty;
        [Parameter, SupplyParameterFromQuery] public int RecordsNumber { get; set; } = 10;

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var responseHttp = await Repository.GetAsync<List<ElectoralJourney>>("api/electoralJourneys");
            ElectoralJourneys = responseHttp.Response;
        }

    }
}
