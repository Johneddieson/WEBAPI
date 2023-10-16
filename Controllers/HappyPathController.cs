using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static WEBAPI.DTO.SampleData;
using System.Security.Claims;
using WEBAPI.Interfaces;
using static WEBAPI.DTO.HappyPathFields;

namespace WEBAPI.Controllers
{

    [ApiController]
    [Route("api/{controller}")]
    public class HappyPathController : ControllerBase
    {

        private readonly IHappyPathService _IhappyPathService;

        public HappyPathController(IHappyPathService happyPathService) 
        {
        _IhappyPathService = happyPathService;
        
        }




        [HttpPost]
        [Route("InsertingHappyPathProcess")]
        public async Task<IActionResult> InsertingHappyPathProcess([FromBody] List<HappyPathRequest> happyPathRequest)
        {

            HappyPathResponse happyPathResponse = await _IhappyPathService.InsertingHappyPathProcess(happyPathRequest);

            return StatusCode(Convert.ToInt32(happyPathResponse.statusCode), happyPathResponse);

        }

        [HttpGet]
        [Route("RetrieveInsertedHappyPath")]
        //List<RetrieveInsertedHappyPathReponse>
        public async Task<IActionResult> RetrieveInsertedHappyPath()
        {

            List<RetrieveInsertedHappyPathReponse> retrieveInsertedHappyPathReponses = await _IhappyPathService.RetrieveInsertedHappyPath();

            return Ok(retrieveInsertedHappyPathReponses);

        }

    }
}
