using CaveProvider.Identity.API.Models;

namespace CaveProvider.Identity.API.Interface
{
    public interface IPermissionRepository
    {
        Task<List<string>> GetUserPermissionNames(string userId);
    }
}
