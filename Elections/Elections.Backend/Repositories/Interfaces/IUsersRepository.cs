using Elections.Shared.DTOs;
using Elections.Shared.Entities;
using Elections.Shared.Responses;
using Microsoft.AspNetCore.Identity;
using Orders.Shared.DTOs;

namespace Elections.Backend.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<string> GeneratePasswordResetTokenAsync(User user);

        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);

        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<User> GetUserAsync(string email);

        Task<IEnumerable<User>> GetAllUserAsync();

        Task<User> GetUserAsync(Guid userId);

        Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task<IdentityResult> AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);
        Task<SignInResult> LoginAsync(LoginDTO model);
        Task LogoutAsync();
    }
}
