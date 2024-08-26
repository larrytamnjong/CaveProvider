using System.Net;
using System.Security.Claims;
using System.Security.Principal;

namespace CaveProvider.Identity.API.Helpers
{
    public static class IdentityClaims
    {
        public static string GetEmail(this IPrincipal user)
        {
            if (user.Identity!.IsAuthenticated)
            {
                ClaimsIdentity? claimsIdentity = user.Identity as ClaimsIdentity;
                var email = claimsIdentity!.Claims.Where(c => c.Type == "Email").FirstOrDefault();
                return email == null ? "" : email.Value;
            }
            else return "";
        }

        public static string GetUserId(this IPrincipal user)
        {

            if (user.Identity!.IsAuthenticated)
            {
                ClaimsIdentity? claimsIdentity = user.Identity as ClaimsIdentity;
                var userId = claimsIdentity!.Claims.Where(c => c.Type == "UserId").FirstOrDefault();
                return userId == null ? "" : userId.Value;
            }
            else return "";
        }
        
    }
}
