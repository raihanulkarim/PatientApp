using AssignmentExcelbd.Backend.Repositories;
using AssignmentExcelbd.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentExcelbd.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiseasesController : ControllerBase
    {
        private readonly IDiseaseRepository diseaseRepository;

        public DiseasesController(IDiseaseRepository diseaseRepository)
        {
            this.diseaseRepository = diseaseRepository;
        }

        [HttpGet]
        //api/diseases
        public async Task<ActionResult<DiseasesInfo>> GetDiseases()
        {
            try
            {
                var diseases = await diseaseRepository.GetDiseases();

                return Ok(diseases);
            }
            catch (Exception ex)
            {
                return BadRequest("Error while getting diseases information. Message:" + ex.Message);
            }
        }

    }
}
