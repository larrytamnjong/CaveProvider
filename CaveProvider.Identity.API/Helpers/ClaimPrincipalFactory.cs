using CaveProvider.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Data;
using System.Security.Claims;

namespace CaveProvider.Identity.API.Helpers
{
    public class ClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
    {
        public ClaimsPrincipalFactory(UserManager<ApplicationUser> userManager,
                                      RoleManager<ApplicationRole> roleManager,
                                      IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor)
        { }

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            //var roles = await UserManager.GetRolesAsync(user);
            var principal = await base.CreateAsync(user);
            var identity = principal.Identity as ClaimsIdentity;

            if (identity == null)
            {
                return principal;
            }

            if (!string.IsNullOrWhiteSpace(user.GivenName))
            {
                identity.AddClaims([new Claim(ClaimTypes.GivenName, user.GivenName)]);
            }

            if (!string.IsNullOrWhiteSpace(user.LanguageId.ToString()))
            {
                identity.AddClaims([new  Claim("LanguageId", user.LanguageId.ToString())]);
            }

            if (!string.IsNullOrWhiteSpace(user.UserName))
            {
                identity.AddClaims([ new Claim("UserName", user.UserName)]);
            }

            if (!string.IsNullOrWhiteSpace(user.Id))
            {
                identity.AddClaims([ new Claim("UserId", user.Id)]);
            }

            /*
            //We do not need this because roles are already added to claims when the CreateAsyncMethod is called
            if (roles != null)
            {
                foreach (var role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }
            }
            */


            return principal;
        }
    }
}
