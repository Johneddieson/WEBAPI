using System.Net;

namespace WEBAPI.DTO
{
    public class LoginFields
    {


        public class LoginFieldRequest
        {


            public string? email { get; set; }
            public string? password { get; set; }
        }


        public class UserFields
        {

            public long userid { get; set; }
            public string? firstname { get; set; }
            public string? middlename { get; set; }
            public string? lastname { get; set; }
            public string? email { get; set; }
            public string? password { get; set; }
        }


        public class GetUserData
        {
            public long nameidentifier { get; set; }
            public string? name { get; set; }
            public string? email { get; set; }
            
        }


        public class LoginResponse
        {
            public HttpStatusCode statusCode { get; set; }

            public string? message { get; set; }
            public bool isSuccess { get; set; }



        }
    }
}
