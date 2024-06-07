using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Frontend.Repositories;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;

namespace Elections.Frontend.Pages.Results
{
    public partial class Results
    {
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Parameter, SupplyParameterFromQuery] public string Page { get; set; } = string.Empty;
        [Parameter, SupplyParameterFromQuery] public string Filter { get; set; } = string.Empty;
        [Parameter, SupplyParameterFromQuery] public int RecordsNumber { get; set; } = 10;
        public List<ElectoralJourney>? ElectoralJourneys { get; set; }

        private readonly String ELECTORAL_JOURNEY_PATH = "api/electoralJourneys";
        private int currentPage = 1;
        private int totalPages;

        protected override async Task OnInitializedAsync()
        {
           await LoadElectoralJourneysAsync();
        }

        private async Task SelectedPageAsync(int page)
        {
            currentPage = page;
            await LoadAsync(page);
        }
        private async Task ApplyFilterAsync(string filter)
        {
            Filter = filter;
            int page = 1;
            await LoadAsync(page);
            await SelectedPageAsync(page);
        }
        private async Task SelectedRecordsNumberAsync(int recordsnumber)
        {
            RecordsNumber = recordsnumber;
            int page = 1;
            await LoadAsync(page);
            await SelectedPageAsync(page);
        }

        private async Task LoadElectoralJourneysAsync()
        {
            await LoadAsync();
        }

        private async Task LoadAsync(int page = 1)
        {
            if (!string.IsNullOrWhiteSpace(Page))
            {
                page = Convert.ToInt32(Page);
            }

            var ok = await LoadListAsync(page);
            if (ok)
            {
                await LoadPagesAsync();
            }
        }

        private async Task<bool> LoadListAsync(int page)
        {
            validateRecordsNumber(RecordsNumber);
            var url = string.Concat(ELECTORAL_JOURNEY_PATH, $"?page={page}", $"&recordsnumber={RecordsNumber}");
            if (!string.IsNullOrEmpty(Filter))
            {
                url += $"&filter={Filter}";
            }

            var responseHttp = await Repository.GetAsync<List<ElectoralJourney>>(url);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return false;
            }
            ElectoralJourneys = responseHttp.Response;
            var getDate = DateTime.Now;
            ElectoralJourneys = ElectoralJourneys.Where(x => x.DateFinish < getDate).ToList();
            return true;
        }

        private async Task LoadPagesAsync()
        {
            var url = string.Concat(ELECTORAL_JOURNEY_PATH, "/totalPages", $"?recordsnumber={RecordsNumber}");
            if (!string.IsNullOrEmpty(Filter))
            {
                url += $"&filter={Filter}";
            }

            var responseHttp = await Repository.GetAsync<int>(url);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }
            totalPages = responseHttp.Response;
        }

        private void validateRecordsNumber(int recordsnumber)
        {
            if (recordsnumber == 0)
            {
                RecordsNumber = 10;
            }
        }
    }
}
