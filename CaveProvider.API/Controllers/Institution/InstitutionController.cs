using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CaveProvider.Core.Model.Institution;
using CaveProvider.Domain.Interface;
using CaveProvider.Core.Helpers.Enums;
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
            try
            {

                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, result.First());
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }


        }

       [Authorize(Roles = "Institution Setup")]
        [HttpPost]
        [Route("addorupdateinstitutiondetails")]
        public async Task<IActionResult> AddOrUpdateInstitionDetails([FromBody] Institution institution)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
