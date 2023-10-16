using System.Collections.Generic;
using WEBAPI.Interfaces;
using static WEBAPI.DTO.SampleData;
using System.Linq;
using Newtonsoft.Json;
using WEBAPI.DTO;
using WEBAPI.Context;
using Dapper;

namespace WEBAPI.Services
{

    public class SampleService : ISampleService
    {

        private readonly DatabaseContext _databaseContext;

        public SampleService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }




        public async Task<List<RetrieveSampleData>> SampleRetrieveData()
        {
            List<RetrieveSampleData> retrieveSampleDatas = new List<RetrieveSampleData>();

            try
            {

                using (StreamReader r = new StreamReader("Files/MyFile.json"))
                {
                    string json = r.ReadToEnd();

                    List<RetrieveSampleData> sampledata = JsonConvert.DeserializeObject<List<RetrieveSampleData>>(json) ?? new List<RetrieveSampleData>();



                    retrieveSampleDatas = (from row in sampledata
                                           select new RetrieveSampleData
                                           {
                                               DataProcess = row.DataProcess,
                                               Date = row.Date,
                                               CheckVoucher = row.CheckVoucher,
                                               Bank = row.Bank,
                                               Payee = row.Payee,
                                               Particulars = row.Particulars,
                                               OFWorSL = row.OFWorSL,
                                               C3CapexCredit = row.C3CapexCredit,
                                               LoanGroup = row.LoanGroup,
                                               Company = row.Company,
                                               InterestRate = row.InterestRate,
                                               Term = row.Term,
                                               FirstAmorization = row.FirstAmorization,
                                               DueDate = row.DueDate
                                           }).ToList();


                }

            }
            catch (Exception ex)
            {


            }
            return retrieveSampleDatas;
        }



        public async Task<string> SampleRetrieveDataFromDatabase() 
        {
            string response = "";
            var query = "select * from main.Applications";
            try
            {
                 using (var connection = _databaseContext.CreateConnection()) 
                {
                    var mainApplications = await connection.QueryAsync(query);

                    mainApplications.ToList();
                }

                response = "ediwow!";
            }
            catch(Exception ex) 
            {

                response = ex.Message.ToString();
            }
            return response;
        }
    }
}
