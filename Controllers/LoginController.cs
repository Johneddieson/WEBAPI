using Microsoft.AspNetCore.Mvc;
using WEBAPI.Interfaces;
using static WEBAPI.DTO.LoginFields;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("Credential/{controller}")]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService _IloginService;




        public LoginController(ILoginService loginService)
        {
            _IloginService = loginService; 
        }


        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUser([FromBody] LoginFieldRequest request)
        {
            GetUserData getUserData = new GetUserData();
            LoginResponse LoginResponse = await _IloginService.LoginRequest(request);

            return StatusCode(Convert.ToInt32(LoginResponse.statusCode), LoginResponse);
        }
    }
}
