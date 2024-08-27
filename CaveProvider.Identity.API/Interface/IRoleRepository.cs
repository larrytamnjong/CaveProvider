using CaveProvider.Identity.API.Models;
using Microsoft.AspNetCore.Identity;

namespace CaveProvider.Identity.API.Interface
{
    public interface IRoleRepository
    {
        Task<IdentityResult> AssignAllRolesToUser(ApplicationUser user);
        Task<List<string>> GetUserRoles(string userId);
    }
}
