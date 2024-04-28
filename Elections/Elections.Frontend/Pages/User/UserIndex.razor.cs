using CurrieTechnologies.Razor.SweetAlert2;
using Elections.Frontend.Repositories;
using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Microsoft.AspNetCore.Components;

namespace Elections.Frontend.Pages.User
{
    public partial class UserIndex
    {
        [Inject] private IRepository repository { get; set; } = null!;        
        public List<UserDTO>? listUsers { get; set; }
        private int currentPage = 1;
        private int totalPages;

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var responseHttp = await repository.GetAsync<List<UserDTO>>("api/users");
            listUsers = responseHttp.Response;
        }
    }

}
