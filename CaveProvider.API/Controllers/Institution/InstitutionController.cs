using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaveProvider.API.Controllers.Institution
{
    [Route("api/[controller]")]
    public class InstitutionController : Controller
    {
        public InstitutionController() { }

        [Authorize(Roles = "Super Administrator, Settings")]
        [HttpPost]
        [Route("createinstitution")]
        
        public IActionResult CreateInstitution() 
        {
            return StatusCode(StatusCodes.Status200OK, "Great job");
        }
    }
}
