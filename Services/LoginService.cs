using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WEBAPI.Controllers;
using WEBAPI.Interfaces;
using static WEBAPI.DTO.LoginFields;
using static WEBAPI.DTO.SampleData;

namespace WEBAPI.Services
{
    public class LoginService: ILoginService
    {

        IConfiguration _configuration;
        private readonly JwtAuthenticationManager jwtAuthenticationManager;
        public LoginService(IConfiguration configuration, JwtAuthenticationManager jwtAuthenticationManager) 
        {
            _configuration = configuration;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }



        public async Task<LoginResponse> LoginRequest(LoginFieldRequest request) 
        {

            LoginResponse loginResponse = new LoginResponse();


            try
            {
                using (StreamReader r = new StreamReader("Files/Users.json"))
                {
                    string json = r.ReadToEnd();

                    List<UserFields> sampledata = JsonConvert.DeserializeObject<List<UserFields>>(json) ?? new List<UserFields>();

                    var checkIfEmailIsExisting = sampledata.Where(w => w.email == request.email && w.password == request.password).FirstOrDefault();


                    if (checkIfEmailIsExisting == null) 
                    {

                        loginResponse = new LoginResponse
                        {
                            isSuccess = false,
                            statusCode = (System.Net.HttpStatusCode)StatusCodes.Status500InternalServerError,
                            message = "Invalid Credentials"
                        };
                    }
                    else
                    {
                        var token = jwtAuthenticationManager.Authenticate(checkIfEmailIsExisting);
                        loginResponse = new LoginResponse
                        {
                            isSuccess = true,
                            statusCode = (System.Net.HttpStatusCode)StatusCodes.Status200OK,
                            message = token
                        };

                            
                       

                    }


                }
            }
            catch(Exception ex) 
            {
            
            }
            return loginResponse;


        }

    }
}
