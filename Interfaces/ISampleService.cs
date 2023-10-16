using static WEBAPI.DTO.SampleData;

namespace WEBAPI.Interfaces
{
    public interface ISampleService
    {


        Task<List<RetrieveSampleData>> SampleRetrieveData();
        Task<string> SampleRetrieveDataFromDatabase();


    }
}
