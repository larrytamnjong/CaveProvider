using CaveProvider.Identity.API.Helpers;
using CaveProvider.Identity.API.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaveProvider.Identity.API.Controllers
{
    [Route("api/[controller]")]
    public class PermissionController : Controller
    {
        private readonly IPermissionRepository permissionRepository;
        public PermissionController(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }


        [HttpGet]
        [Authorize]
        [Route("getuserpermissionnames")]
        public async Task<IActionResult> GetUserPermissionNames()
        {
            try
            {
                var userId = User.GetUserId();
                var userPermissions = await permissionRepository.GetUserPermissionNames(userId);
                return StatusCode(StatusCodes.Status200OK, (userPermissions));
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new List<string>());
            }
        }
    }
}
