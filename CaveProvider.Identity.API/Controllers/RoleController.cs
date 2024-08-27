using CaveProvider.Identity.API.Helpers;
using CaveProvider.Identity.API.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaveProvider.Identity.API.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleRepository roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [Authorize]
        [HttpGet]
        [Route("getsignedinuserroles")]
        public async Task<IActionResult> GetSignedInUserRoles()
        {
            var result = await roleRepository.GetUserRoles(User.GetUserId());
            return StatusCode(StatusCodes.Status200OK, result);

        }

    }
}
