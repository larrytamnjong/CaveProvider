using CaveProvider.Core.Helpers.Enums;
using CaveProvider.Core.Model.Institution;
using CaveProvider.Domain.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaveProvider.API.Controllers
{
    [Route("api/[controller]")]
    public class AcademicYearController : Controller
    {
        private readonly IAcademicYearDomain academicPeriodDomain;
        public AcademicYearController(IAcademicYearDomain academicYearDomain)
        {
            this.academicPeriodDomain = academicYearDomain;

        }

        [Authorize(Roles = "Institution Setup")]
        [HttpGet]
        [Route("getacademicyears")]
        public async Task<IActionResult> GetAcademicYear()
        {
            var result = await academicPeriodDomain.GetEntities();
            if(result.Count() > 0)
            {
                return StatusCode(StatusCodes.Status200OK, result);
            }
            return StatusCode(StatusCodes.Status200OK);
        }


        [Authorize(Roles = "Institution Setup")]
        [HttpPut]
        [Route("updateacademicyear")]
        public async Task<IActionResult> UpdateAcademicYear([FromBody] AcademicYear academicYear)
        {
            var result = await academicPeriodDomain.UpdateEntity(academicYear);
            if (result.Status == ResposityActionResultStatus.Updated)
            {
                return StatusCode(StatusCodes.Status200OK, result.Entity);
            }
            return StatusCode(StatusCodes.Status304NotModified, result.Entity);
        }


        [Authorize(Roles = "Institution Setup")]
        [HttpPost]
        [Route("addacademicyear")]
        public async Task<IActionResult> AddAcademicYear([FromBody] AcademicYear academicYear)
        {
            var result = await academicPeriodDomain.AddEntity(academicYear);
            if (result.Status == ResposityActionResultStatus.Created)
            {
                return StatusCode(StatusCodes.Status200OK, result.Entity);
            }
            return StatusCode(StatusCodes.Status304NotModified, result.Entity);
        }


        [Authorize(Roles = "Institution Setup")]
        [HttpDelete]
        [Route("deleteacademicyear")]
        public async Task<IActionResult> DeleteYear([FromBody] AcademicYear academicYear)
        {
            var result = await academicPeriodDomain.DeleteEntity(academicYear);
            if (result.Status == ResposityActionResultStatus.Deleted)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            return StatusCode(StatusCodes.Status304NotModified);
        }

    }
}
