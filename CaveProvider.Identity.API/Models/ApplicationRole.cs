using Microsoft.AspNetCore.Identity;

namespace CaveProvider.Identity.API.Models
{
    public class ApplicationRole: IdentityRole
    {
        public List<RolePermission>? RolePermissions { get; set; }

    }
}
