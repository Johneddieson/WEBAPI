using static WEBAPI.DTO.LoginFields;

namespace WEBAPI.Interfaces
{
    public interface ILoginService
    {


        Task<LoginResponse> LoginRequest(LoginFieldRequest request);
    }
}
