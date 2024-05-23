using AssignmentExcelbd.Backend.Repositories;
using AssignmentExcelbd.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentExcelbd.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly IAllergiesRepository allergiesRepository;

        public AllergiesController(IAllergiesRepository allergiesRepository)
        {
            this.allergiesRepository = allergiesRepository;
        }

        [HttpGet]
        //api/allergies
        public async Task<ActionResult<DiseasesInfo>> Getallergies()
        {
            try
            {
                var allergies = await allergiesRepository.GetAllergies();

                return Ok(allergies);
            }
            catch (Exception ex)
            {
                return BadRequest("Error while getting allergies information. Message:" + ex.Message);
            }
        }

    }
}
