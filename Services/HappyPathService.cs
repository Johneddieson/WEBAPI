using Dapper;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WEBAPI.Context;
using WEBAPI.Interfaces;
using static WEBAPI.DTO.HappyPathFields;

namespace WEBAPI.Services
{
    public class HappyPathService : IHappyPathService
    {

        private readonly DatabaseContext _databaseContext;

        public HappyPathService(DatabaseContext databaseContext)
        {

            _databaseContext = databaseContext;
        }



        public async Task<HappyPathResponse> InsertingHappyPathProcess(List<HappyPathRequest> happyPathRequest)
        {
            HappyPathResponse happyPathResponse = new HappyPathResponse();

            try
            {


                happyPathRequest.ForEach(fe =>
                {

                    var query = "insert into main.Borrowers (borrowerNumber, lastName, firstName, middleName, suffixName, civilStatusId, birthdayOn) output inserted.id values (@borrowerNumber, @lastName, @firstName, @middleName, @suffixName, @civilStatusId, @birthdayOn)";

                    var parameters = new DynamicParameters();

                    parameters.Add("borrowerNumber", fe.num, DbType.String);
                    parameters.Add("lastName", fe.BorrowerName, DbType.String);
                    parameters.Add("firstName", fe.BorrowerFirstName, DbType.String);
                    parameters.Add("middleName", fe.BorrowerMiddleName, DbType.String);
                    parameters.Add("suffixName", "", DbType.String);
                    parameters.Add("civilStatusId", 1, DbType.Int32);
                    parameters.Add("birthdayOn", Convert.ToDateTime(fe.BirthDate), DbType.DateTime);



                    using (var connection = _databaseContext.CreateConnection())
                    {

                        var borroweridentityid = connection.Query<int>(query, parameters).FirstOrDefault();



                        var queryForInsertingApplications = "insert into main.Applications (applicationNumber, valueOn, productId, startOn, principal, interest, term, paymentCount, interestOptionId, loanTypeId, paymentMethodId, borrowerId, userId) output inserted.id " +
                            "values (@applicationNumber, @valueOn, @productId, @startOn, @principal, @interest, @term, @paymentCount, @interestOptionId, @loanTypeId, @paymentMethodId, @borrowerId, @userId)";


                        var parameterForApplications = new DynamicParameters();

                        parameterForApplications.Add("applicationNumber", fe.num, DbType.String);
                        parameterForApplications.Add("valueOn", Convert.ToDateTime(fe.DatePrepared), DbType.DateTime);
                        parameterForApplications.Add("productId", 1, DbType.Int32);
                        parameterForApplications.Add("startOn", Convert.ToDateTime(fe.DatePrepared), DbType.DateTime);
                        parameterForApplications.Add("principal", 5.33, DbType.Decimal);
                        parameterForApplications.Add("interest", Convert.ToDecimal(fe.InterestRate), DbType.Decimal);
                        parameterForApplications.Add("term", Convert.ToInt32(fe.Term), DbType.Int32);
                        parameterForApplications.Add("paymentCount", 0, DbType.Int32);
                        parameterForApplications.Add("interestOptionId", 1, DbType.Int32);
                        parameterForApplications.Add("loanTypeId", 1, DbType.Int32);
                        parameterForApplications.Add("paymentMethodId", 1, DbType.Int32);
                        parameterForApplications.Add("borrowerId", borroweridentityid, DbType.Int32);
                        parameterForApplications.Add("userId", 1, DbType.Int32);


                        var applicationidentityid = connection.Query<int>(queryForInsertingApplications, parameterForApplications).FirstOrDefault();



                        var queryForInsertingAccounts = "insert into main.accounts (id, accountNumber, accountName, interest, principal, valueOn, net, balance, accountStatusId) output inserted.id " +
                            "values (@id, @accountNumber, @accountName, @interest, @principal, @valueOn, @net, @balance, @accountStatusId)";

                        var parametersForAccounts = new DynamicParameters();

                        parametersForAccounts.Add("id", applicationidentityid, DbType.Int32);
                        parametersForAccounts.Add("accountNumber", fe.Acctnumber, DbType.String);
                        parametersForAccounts.Add("accountName", fe.BorrowerFirstName + " " + fe.BorrowerMiddleName + " " + fe.BorrowerName, DbType.String);
                        parametersForAccounts.Add("interest", Convert.ToDecimal(fe.InterestRate), DbType.Decimal);
                        parametersForAccounts.Add("principal", Convert.ToDecimal(fe.InterestRate), DbType.Decimal);
                        parametersForAccounts.Add("valueOn", Convert.ToDateTime(fe.DatePrepared), DbType.DateTime);
                        parametersForAccounts.Add("net", Convert.ToDecimal(fe.LoanAmount), DbType.Decimal);
                        parametersForAccounts.Add("balance", Convert.ToDecimal(fe.LoanAmount), DbType.Decimal);
                        parametersForAccounts.Add("accountStatusId", 1, DbType.Int32);


                        var accountidentityid = connection.Query<int>(queryForInsertingAccounts, parametersForAccounts).FirstOrDefault();


                    }
                });

                happyPathResponse = new HappyPathResponse
                {
                    isSuccess = true,
                    statusCode = System.Net.HttpStatusCode.OK,
                    message = "Inserted Successfully"
                };


            }
            catch (Exception ex)
            {
                happyPathResponse = new HappyPathResponse
                {
                    isSuccess = false,
                    statusCode = System.Net.HttpStatusCode.InternalServerError,
                    message = ex.Message.ToString()
                };

            }

            return happyPathResponse;
        }


        //public async Task<HappyPathResponse> InsertingHappyPathProcessFORPn(List<HappyPathForPNRequest> happyPathForPNRequest)
        //{
        //    HappyPathResponse happyPathResponse = new HappyPathResponse();

        //    try
        //    {


        //        happyPathForPNRequest.ForEach(fe =>
        //        {

        //            var query = "insert into main.Borrowers (borrowerNumber, lastName, firstName, middleName, suffixName, civilStatusId, birthdayOn) output inserted.id values (@borrowerNumber, @lastName, @firstName, @middleName, @suffixName, @civilStatusId, @birthdayOn)";

        //            var parameters = new DynamicParameters();

        //            parameters.Add("borrowerNumber", fe.num, DbType.String);
        //            parameters.Add("lastName", fe.BorrowerName, DbType.String);
        //            parameters.Add("firstName", fe.BorrowerFirstName, DbType.String);
        //            parameters.Add("middleName", fe.BorrowerMiddleName, DbType.String);
        //            parameters.Add("suffixName", "", DbType.String);
        //            parameters.Add("civilStatusId", 1, DbType.Int32);
        //            parameters.Add("birthdayOn", Convert.ToDateTime(fe.BirthDate), DbType.DateTime);



        //            using (var connection = _databaseContext.CreateConnection())
        //            {

        //                var borroweridentityid = connection.Query<int>(query, parameters).FirstOrDefault();



        //                var queryForInsertingApplications = "insert into main.Applications (applicationNumber, valueOn, productId, startOn, principal, interest, term, paymentCount, interestOptionId, loanTypeId, paymentMethodId, borrowerId, userId) output inserted.id " +
        //                    "values (@applicationNumber, @valueOn, @productId, @startOn, @principal, @interest, @term, @paymentCount, @interestOptionId, @loanTypeId, @paymentMethodId, @borrowerId, @userId)";


        //                var parameterForApplications = new DynamicParameters();

        //                parameterForApplications.Add("applicationNumber", fe.num, DbType.String);
        //                parameterForApplications.Add("valueOn", Convert.ToDateTime(fe.DatePrepared), DbType.DateTime);
        //                parameterForApplications.Add("productId", 1, DbType.Int32);
        //                parameterForApplications.Add("startOn", Convert.ToDateTime(fe.DatePrepared), DbType.DateTime);
        //                parameterForApplications.Add("principal", 5.33, DbType.Decimal);
        //                parameterForApplications.Add("interest", Convert.ToDecimal(fe.InterestRate), DbType.Decimal);
        //                parameterForApplications.Add("term", Convert.ToInt32(fe.Term), DbType.Int32);
        //                parameterForApplications.Add("paymentCount", 0, DbType.Int32);
        //                parameterForApplications.Add("interestOptionId", 1, DbType.Int32);
        //                parameterForApplications.Add("loanTypeId", 1, DbType.Int32);
        //                parameterForApplications.Add("paymentMethodId", 1, DbType.Int32);
        //                parameterForApplications.Add("borrowerId", borroweridentityid, DbType.Int32);
        //                parameterForApplications.Add("userId", 1, DbType.Int32);


        //                var applicationidentityid = connection.Query<int>(queryForInsertingApplications, parameterForApplications).FirstOrDefault();



        //                var queryForInsertingAccounts = "insert into main.accounts (id, accountNumber, accountName, interest, principal, valueOn, net, balance, accountStatusId) output inserted.id " +
        //                    "values (@id, @accountNumber, @accountName, @interest, @principal, @valueOn, @net, @balance, @accountStatusId)";

        //                var parametersForAccounts = new DynamicParameters();

        //                parametersForAccounts.Add("id", applicationidentityid, DbType.Int32);
        //                parametersForAccounts.Add("accountNumber", fe.Acctnumber, DbType.String);
        //                parametersForAccounts.Add("accountName", fe.BorrowerFirstName + " " + fe.BorrowerMiddleName + " " + fe.BorrowerName, DbType.String);
        //                parametersForAccounts.Add("interest", Convert.ToDecimal(fe.InterestRate), DbType.Decimal);
        //                parametersForAccounts.Add("principal", Convert.ToDecimal(fe.InterestRate), DbType.Decimal);
        //                parametersForAccounts.Add("valueOn", Convert.ToDateTime(fe.DatePrepared), DbType.DateTime);
        //                parametersForAccounts.Add("net", Convert.ToDecimal(fe.LoanAmount), DbType.Decimal);
        //                parametersForAccounts.Add("balance", Convert.ToDecimal(fe.LoanAmount), DbType.Decimal);
        //                parametersForAccounts.Add("accountStatusId", 1, DbType.Int32);


        //                var accountidentityid = connection.Query<int>(queryForInsertingAccounts, parametersForAccounts).FirstOrDefault();


        //            }
        //        });

        //        happyPathResponse = new HappyPathResponse
        //        {
        //            isSuccess = true,
        //            statusCode = System.Net.HttpStatusCode.OK,
        //            message = "Inserted Successfully"
        //        };


        //    }
        //    catch (Exception ex)
        //    {
        //        happyPathResponse = new HappyPathResponse
        //        {
        //            isSuccess = false,
        //            statusCode = System.Net.HttpStatusCode.InternalServerError,
        //            message = ex.Message.ToString()
        //        };

        //    }

        //    return happyPathResponse;
        //}




        public async Task<List<RetrieveInsertedHappyPathReponse>> RetrieveInsertedHappyPath()
        {
            List<RetrieveInsertedHappyPathReponse> response = new List<RetrieveInsertedHappyPathReponse>();

            try
            {

                var query = "select  a.id as borrowerID, a.borrowerNumber, a.lastName, a.firstName, a.middleName, a.suffixName, a.civilStatusId, a.birthdayOn, b.id as applicationId, b.applicationNumber, b.valueOn, b.productId, b.startOn, b.principal, b.interest, b.term, b.paymentCount, b.interestOptionId, b.loanTypeId, b.paymentMethodId, b.borrowerId as borroweridentifier, b.userId, c.id as accountId, c.accountNumber, c.accountName, c.interest as accountInterest, c.principal as accountPrincipal, c.valueOn as accountsValueOn, c.net, c.balance, c.accountStatusId from main.borrowers as a inner join main.Applications as b on a.id = b.borrowerId inner join main.Accounts as c on b.id = c.id order by b.valueOn desc";
            
                using (var connection = _databaseContext.CreateConnection()) 
                {
                    var queryresponse = connection.Query<RetrieveInsertedHappyPathReponse>(query).ToList();


                    response.AddRange(queryresponse);


                } 
            
            }
            catch (Exception ex)
            {


            }
            return response;
        }





    }
}
