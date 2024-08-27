using CaveProvider.Identity.API.Database.Context.Interface;
using CaveProvider.Identity.API.Interface;
using CaveProvider.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Security;

namespace CaveProvider.Identity.API.Repository
{
    public class RoleRepository: IRoleRepository
    {
        private readonly IApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
      
        public RoleRepository(IApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager) 
        { 
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        

        public async Task<IdentityResult> AssignAllRolesToUser(ApplicationUser user)
        {
            try
            {
                var roles = await roleManager.Roles.Select(role =>  role.Name).ToListAsync();   
                var result = await userManager.AddToRolesAsync(user, roles!);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<string>> GetUserRoles(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            var roles = await userManager.GetRolesAsync(user!);
            
            
            return roles.ToList() ?? [];
        }
    }
}
