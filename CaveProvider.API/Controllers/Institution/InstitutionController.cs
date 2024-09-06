using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CaveProvider.Core.Model;
using CaveProvider.Domain.Interface;
using CaveProvider.Core.Helpers.Enums;
using CaveProvider.Core.Model.Institution;
namespace CaveProvider.API.Controllers
{
    [Route("api/[controller]")]
    public class InstitutionController : Controller
    {
        private readonly IInstitutionDomain institutionDomain;
        public InstitutionController(IInstitutionDomain institutionDomain)
        {
            this.institutionDomain = institutionDomain;

        }

        [Authorize(Roles = "Institution Setup")]
        [HttpGet]
        [Route("getinstitutiondetails")]

        public async Task<IActionResult> GetInstitutionDetails()
        {
            var result = await institutionDomain.GetEntities();
            if (result.Count() > 0)
            {

                return StatusCode(StatusCodes.Status200OK, result.First());
            }
            return StatusCode(StatusCodes.Status202Accepted);

        }

        [Authorize(Roles = "Institution Setup")]
        [HttpPost]
        [Route("addorupdateinstitutiondetails")]
        public async Task<IActionResult> AddOrUpdateInstitionDetails([FromBody] Institution institution)
        {

            var result = await institutionDomain.UpdateEntity(institution);

            if (result.Status == ResposityActionResultStatus.Updated)
            {
                return StatusCode(StatusCodes.Status201Created, result.Entity);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, result.Entity);
            }
        }
    }
}
