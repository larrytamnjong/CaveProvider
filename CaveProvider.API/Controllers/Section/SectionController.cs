using CaveProvider.Core.Helpers.Enums;
using CaveProvider.Core.Model;
using CaveProvider.Core.Model.Institution;
using CaveProvider.Domain;
using CaveProvider.Domain.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaveProvider.API.Controllers
{
    [Route("api/[controller]")]
    public class SectionController : Controller
    {
        private readonly ISectionDomain sectionDomain;
        public SectionController(ISectionDomain domain) 
        { 
          sectionDomain = domain;
        
        }

        [Authorize(Roles = "Institution Setup")]
        [HttpGet]
        [Route("getsections")]
        public async Task<IActionResult> GetSections()
        {
            var result = await sectionDomain.GetEntities();
            if (result.Count() > 0)
            {
                return StatusCode(StatusCodes.Status200OK, result);
            }
            return StatusCode(StatusCodes.Status200OK);
        }


        [Authorize(Roles = "Institution Setup")]
        [HttpPut]
        [Route("updatesection")]
        public async Task<IActionResult> UpdateTerm([FromBody] Section section)
        {
            var result = await sectionDomain.UpdateEntity(section);
            if (result.Status == ResposityActionResultStatus.Updated)
            {
                return StatusCode(StatusCodes.Status200OK, result.Entity);
            }
            return StatusCode(StatusCodes.Status304NotModified, result.Entity);
        }


        [Authorize(Roles = "Institution Setup")]
        [HttpPost]
        [Route("addsection")]
        public async Task<IActionResult> AddAcademicYear([FromBody] Section section)
        {
            var result = await sectionDomain.AddEntity(section);
            if (result.Status == ResposityActionResultStatus.Created)
            {
                return StatusCode(StatusCodes.Status200OK, result.Entity);
            }
            return StatusCode(StatusCodes.Status304NotModified, result.Entity);
        }


        [Authorize(Roles = "Institution Setup")]
        [HttpDelete]
        [Route("deletesection")]
        public async Task<IActionResult> DeleteYear([FromBody] Section section)
        {
            var result = await sectionDomain.DeleteEntity(section);
            if (result.Status == ResposityActionResultStatus.Deleted)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            return StatusCode(StatusCodes.Status304NotModified);
        }

    }
}
