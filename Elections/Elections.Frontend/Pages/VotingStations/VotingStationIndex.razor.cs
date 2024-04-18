using Elections.Frontend.Repositories;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.Metrics;

namespace Elections.Frontend.Pages.VotingStations
{
    partial class VotingStationIndex
    {
        [Inject] private IRepository Repository { get; set; } = null!;
        public List<VotingStation>? VotingStations { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var responseHppt = await Repository.GetAsync<List<VotingStation>>("/api/VotingStation");
            VotingStations = responseHppt.Response!;
        }

    }
}
