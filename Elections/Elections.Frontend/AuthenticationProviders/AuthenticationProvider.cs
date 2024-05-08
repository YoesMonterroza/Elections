using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Elections.Frontend.AuthenticationProviders
{
    public class AuthenticationProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var Anonymous = new ClaimsIdentity();
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(Anonymous)));
        }
    }
}
