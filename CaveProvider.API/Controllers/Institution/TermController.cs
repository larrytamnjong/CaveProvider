using CaveProvider.Core.Helpers.Enums;
using CaveProvider.Core.Model.Institution;
using CaveProvider.Domain.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaveProvider.API.Controllers
{
    [Route("api/[controller]")]
    public class TermController : Controller
    {
       private readonly ITermDomain termDomain;
        public TermController(ITermDomain termDomain)
        {
            this.termDomain = termDomain;
        }

        [Authorize(Roles = "Institution Setup")]
        [HttpGet]
        [Route("getterms")]
        public async Task<IActionResult> GetTerms()
        {
            var result = await termDomain.GetEntities();
            if (result.Count() > 0)
            {
                return StatusCode(StatusCodes.Status200OK, result);
            }
            return StatusCode(StatusCodes.Status200OK);
        }


        [Authorize(Roles = "Institution Setup")]
        [HttpPut]
        [Route("updateterm")]
        public async Task<IActionResult> UpdateTerm([FromBody] Term term)
        {
            var result = await termDomain.UpdateEntity(term);
            if (result.Status == ResposityActionResultStatus.Updated)
            {
                return StatusCode(StatusCodes.Status200OK, result.Entity);
            }
            return StatusCode(StatusCodes.Status304NotModified, result.Entity);
        }


        [Authorize(Roles = "Institution Setup")]
        [HttpPost]
        [Route("addterm")]
        public async Task<IActionResult> AddAcademicYear([FromBody] Term term)
        {
            var result = await termDomain.AddEntity(term);
            if (result.Status == ResposityActionResultStatus.Created)
            {
                return StatusCode(StatusCodes.Status200OK, result.Entity);
            }
            return StatusCode(StatusCodes.Status304NotModified, result.Entity);
        }


        [Authorize(Roles = "Institution Setup")]
        [HttpDelete]
        [Route("deleteterm")]
        public async Task<IActionResult> DeleteYear([FromBody] Term term)
        {
            var result = await termDomain.DeleteEntity(term);
            if (result.Status == ResposityActionResultStatus.Deleted)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            return StatusCode(StatusCodes.Status304NotModified);
        }

    }
}
