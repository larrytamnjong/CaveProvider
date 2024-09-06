using CaveProvider.Core.Model.Institution;
using CaveProvider.Domain.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaveProvider.API.Controllers
{
    [Route("api/[controller]")]
    public class AcademicPeriodController : Controller
    {
        private readonly IAcademicPeriodDomain academicPeriodDomain;
        public AcademicPeriodController(IAcademicPeriodDomain academicPeriodDomain)
        {
            this.academicPeriodDomain = academicPeriodDomain;

        }

        [Authorize(Roles = "Institution Setup")]
        [HttpGet]
        [Route("getacademicperiods")]
        public async Task<IActionResult> GetAcademicPeriods()
        {
            return  Ok(academicPeriodDomain.GetEntities());   
        }


        [Authorize(Roles = "Institution Setup")]
        [HttpPut]
        [Route("updateacademicperiod")]
        public async Task<IActionResult> UpdateAcademicPeriod([FromBody] AcademicPeriod academicPeriod)
        {
            return Ok(academicPeriodDomain.UpdateEntity(academicPeriod));
        }

        [Authorize(Roles = "Institution Setup")]
        [HttpDelete]
        [Route("deleteacademicperiod")]
        public async Task<IActionResult> DeletePeriod([FromBody] AcademicPeriod academicPeriod)
        {
            return Ok(academicPeriodDomain.DeleteEntity(academicPeriod));
        }


    }
}
