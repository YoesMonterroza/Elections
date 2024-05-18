using Blazored.Modal.Services;
using Elections.Frontend.Pages.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;

namespace Elections.Frontend.Shared
{
    public partial class AuthLinks
    {
        private string? photoUser;
        private string nameUser = "Usuario";

        [CascadingParameter] private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;
        [CascadingParameter] IModalService Modal { get; set; } = default!;

        protected override async Task OnParametersSetAsync()
        {
            var authenticationState = await AuthenticationStateTask;
            var claims = authenticationState.User.Claims.ToList();
            var photoClaim = claims.FirstOrDefault(x => x.Type == "Photo");
            if (photoClaim is not null)
            {
                photoUser = photoClaim.Value;
            }
            var nameClaim = claims.FirstOrDefault(x => x.Type == "FirstName");
            var lastNameClaim = claims.FirstOrDefault(x => x.Type == "LastName");
            if (nameClaim is not null && lastNameClaim is not null)
            {
                nameUser = string.Concat(nameClaim.Value, " ", lastNameClaim.Value);
            }
        }

        private void ShowModal()
        {
            Modal.Show<Login>();
        }
    }
}
