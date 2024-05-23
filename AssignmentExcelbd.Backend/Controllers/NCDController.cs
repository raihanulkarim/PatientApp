using AssignmentExcelbd.Backend.Repositories;
using AssignmentExcelbd.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentExcelbd.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCDsController : ControllerBase
    {
        private readonly INCDRepository ncdsRepository;

        public NCDsController(INCDRepository ncdsRepository)
        {
            this.ncdsRepository = ncdsRepository;
        }

        [HttpGet]
        //api/ncds
        public async Task<ActionResult<DiseasesInfo>> GetNcds()
        {
            try
            {
                var ncds = await ncdsRepository.GetNCDs();

                return Ok(ncds);
            }
            catch (Exception ex)
            {
                return BadRequest("Error while getting ncds information. Message:" + ex.Message);
            }
        }

    }
}
