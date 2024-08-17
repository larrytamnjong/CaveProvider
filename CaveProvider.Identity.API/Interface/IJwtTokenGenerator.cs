using CaveProvider.Identity.API.Models;

namespace CaveProvider.Identity.API.Interface
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateToken(ApplicationUser user);
    }
}
