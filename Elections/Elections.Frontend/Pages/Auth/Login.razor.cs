using Blazorise;
using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Frontend.Repositories;
using Elections.Frontend.Services;
using Elections.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using Orders.Shared.DTOs;

namespace Elections.Frontend.Pages.Auth
{
    public partial class Login
    {
        private LoginDTO loginDTO = new();
        private Validations validations;

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private ILoginService LoginService { get; set; } = null!;

        private async Task LoginAsync()
        {
            if (await validations.ValidateAll())
            {
                var responseHttp = await Repository.PostAsync<LoginDTO, TokenDTO>("/api/accounts/Login", loginDTO);
                if (responseHttp.Error)
                {
                    var message = await responseHttp.GetErrorMessageAsync();
                    await SweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                    return;
                }

                await LoginService.LoginAsync(responseHttp.Response!.Token);
                NavigationManager.NavigateTo("/");
            }
        }

    }
}