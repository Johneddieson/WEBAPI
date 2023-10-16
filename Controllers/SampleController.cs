using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WEBAPI.Interfaces;
using static WEBAPI.DTO.LoginFields;
using static WEBAPI.DTO.SampleData;

namespace WEBAPI.Controllers
{
    //[Authorize]

    [ApiController]
    [Route("api/{controller}")]
    public class SampleController : ControllerBase
    {

        private readonly ISampleService _ISampleService; 
        private readonly JwtAuthenticationManager _jwtAuthenticationManager;


        public SampleController(ISampleService iSampleService, JwtAuthenticationManager jwtAuthenticationManager)
        {
            _ISampleService = iSampleService;
            this._jwtAuthenticationManager = jwtAuthenticationManager;
        }


        [HttpGet]
        [Route("SampleRetrieveData")]
        public async Task<IActionResult> SampleRetrieveData() 
        {


            List<RetrieveSampleData> retrieveSampleDatas = await _ISampleService.SampleRetrieveData();
            var userId = User.Claims.Where(w => w.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

            long index = long.Parse(userId!.Value);
       
            return Ok(retrieveSampleDatas);
        }


        [HttpGet]
        [Route("GetCurrentUserLogin")]
        public async Task<IActionResult> GetCurrentUserLogin()
        {
            GetUserData getUserData = new GetUserData();


            if (User.Identity!.IsAuthenticated) { 

            var userId = User.Claims.Where(w => w.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

            var name = User.Claims.Where(w => w.Type == ClaimTypes.Name).FirstOrDefault();

            var email = User.Claims.Where(w => w.Type == ClaimTypes.Email).FirstOrDefault();

            long index = long.Parse(userId!.Value);

            getUserData.nameidentifier = index;
            getUserData.name = name!.Value;
            getUserData.email = email!.Value;

        }
            return Ok(getUserData);
        }


        [HttpGet]
        [Route("SampleRetrieveDataFromDatabase")]
        public async Task<IActionResult> SampleRetrieveDataFromDatabase() 
        {
            string retrivedatafromdatabase = await _ISampleService.SampleRetrieveDataFromDatabase();

            return Ok(retrivedatafromdatabase);
        }
    }

}
