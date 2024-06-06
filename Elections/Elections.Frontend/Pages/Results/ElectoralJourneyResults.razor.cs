using Blazorise.Charts;
using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Frontend.Repositories;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace Elections.Frontend.Pages.Results
{
    public partial class ElectoralJourneyResults
    {
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Parameter] public int ElectoralJourneyId { get; set; }
        PieChart<double> pieChart;
        PieChartOptions pieChartOptions;

        private List<ResultDTO> results;

        protected override async Task OnInitializedAsync()
        {
            pieChartOptions = buildChartOptions();
            await getResults();
        }

        private PieChartOptions buildChartOptions()
        {
            return new PieChartOptions
            {
                Responsive = true,
                MaintainAspectRatio = false,
            };
        }

        private async Task<bool> getResults()
        {
            var url = string.Concat("api/vote/GetResults/", ElectoralJourneyId);

            var responseHttp = await Repository.GetAsync<List<ResultDTO>>(url);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return false;
            }
            results = responseHttp.Response;
            return true;

        }

        ChartData<double> GetChartData()
        {
            return new ChartData<double>
            {
                Datasets = new List<ChartDataset<double>> { GetPieChartDataset() },
                Labels = getLabels()
            };
        }
        PieChartDataset<double> GetPieChartDataset()
        {
            return new PieChartDataset<double>
            {
                Label = "# of randoms",
                Data = getData(),
                BackgroundColor = getColors()                
            };
        }

        List<double> getData()
        {
            double totalvotes = getTotalVotes();
            List<double> values = results.Select(x => (x.nVotes / totalvotes) * 100).ToList();
            return values;
        }

        List<object> getLabels()
        {
            return results.Select(x => (object)x.ElectoralCandidateName).ToList();
        }

        List<string> getColors()
        {
            List<string> colors = new List<string>();
            results.ForEach(x => colors.Add(getRandomColor()));
            return colors;
        }

        string getRandomColor()
        {
            Random random = new Random();

            int red = random.Next(256); 
            int green = random.Next(256);
            int blue = random.Next(256);

            Color randomColor = Color.FromArgb(red, green, blue);

            return ColorToHex(randomColor);
        }

        string ColorToHex(Color color)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
        }

        int getTotalVotes()
        {
            return results.Sum(r => r.nVotes);
        }
    }
}
