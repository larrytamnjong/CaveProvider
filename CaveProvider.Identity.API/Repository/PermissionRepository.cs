using CaveProvider.Identity.API.Database.Context.Interface;
using CaveProvider.Identity.API.Interface;
using CaveProvider.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace CaveProvider.Identity.API.Repository
{
    public class PermissionRepository: IPermissionRepository
    {
        private readonly IApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        public PermissionRepository(IApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager) 
        { 
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<List<string>> GetUserPermissionNames(string userId)
        {
            try
            {
                
                var user = await userManager.FindByIdAsync(userId);
                var roles = await userManager.GetRolesAsync(user!);
               

                var roleIds = await Task.WhenAll(roles.Select(async roleName => (await roleManager.FindByNameAsync(roleName))?.Id));
                var permissionNames = await context.RolePermissions.Where(rp => roleIds.Contains(rp.RoleId))
                                                                   .SelectMany(rp => context.Permissions
                                                                   .Where(p => p.Id == rp.PermissionId)
                                                                   .Select(p => p.Name)).Distinct().ToListAsync();

                return permissionNames ?? [];


            }
            catch (Exception ex)
            {
                return [];
            }
        }
    }
}
