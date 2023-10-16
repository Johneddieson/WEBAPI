using static WEBAPI.DTO.HappyPathFields;

namespace WEBAPI.Interfaces
{
    public interface IHappyPathService
    {


        Task<HappyPathResponse> InsertingHappyPathProcess(List<HappyPathRequest> happyPathRequest);

        Task<List<RetrieveInsertedHappyPathReponse>> RetrieveInsertedHappyPath();
    }
}
