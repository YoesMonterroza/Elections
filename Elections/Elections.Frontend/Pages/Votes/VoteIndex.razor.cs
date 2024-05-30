using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Frontend.Pages.ElectoralCandidates;
using Elections.Frontend.Repositories;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace Elections.Frontend.Pages.Votes
{
    public partial class VoteIndex
    {
        private VoteForm? VoteForm;
        private Vote vote = new();

        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;

        private async Task Create()
        {
            
        }
          
        private void Return()
        {
            VoteForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("Vote/index");
        }

    }
}