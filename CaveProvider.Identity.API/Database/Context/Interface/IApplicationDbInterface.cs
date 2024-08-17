using CaveProvider.Identity.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CaveProvider.Identity.API.Database.Context.Interface
{
    public interface IApplicationDbInterface: IDisposable
    {
         DbSet<Permission> Permissions { get; set; }
         DbSet<RolePermission> RolePermissions { get; set; }
    }
}
