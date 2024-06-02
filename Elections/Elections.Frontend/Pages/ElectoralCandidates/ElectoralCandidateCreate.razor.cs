using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Frontend.Pages.VotingStations;
using Elections.Frontend.Repositories;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Elections.Frontend.Pages.ElectoralCandidates
{
    [Authorize(Roles = "Admin")]
    public partial class ElectoralCandidateCreate
    { 
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;


        private ElectoralCandidateForm? electoralCandidateForm;
        private ElectoralCandidate electoralCandidate = new();
        private readonly String ELECTORAL_CANDIDATE_PATH = "api/ElectoralCandidateRegister";


        private async Task Create()
        {
            Random Rnd = new Random();
            electoralCandidate.Id = Rnd.Next(10000000);
            electoralCandidate.Enabled = true;
            electoralCandidate.RegisterDate = DateTime.Now;
            var responseHttp = await Repository.PostAsync(ELECTORAL_CANDIDATE_PATH, electoralCandidate);
            if (responseHttp.Error)
            {
                var message = await responseHttp.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message);
                return;
            }
            Return();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.Center,
                ShowConfirmButton = true,
                Timer = 3000
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro creado con éxito.");
        }

        private void Return()
        {
            electoralCandidateForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("ElectoralCandidateRegister/full");
        }  
    }
}