using System.Net;

namespace WEBAPI.DTO
{
    public class HappyPathFields
    {



        public class HappyPathResponse
        {

            public string message { get; set; } = string.Empty;

            public HttpStatusCode statusCode { get; set; }

            public bool isSuccess { get; set; }
        }


        public class HappyPathRequest
        {

            public string num { get; set; } = string.Empty;
            public string LoanType { get; set; } = string.Empty;
            public string Acctnumber { get; set; } = string.Empty;
            public string CompanyCode { get; set; } = string.Empty;
            public string BorrowerName { get; set; } = string.Empty;
            public string BorrowerFirstName { get; set; } = string.Empty;
            public string BorrowerMiddleName { get; set; } = string.Empty;
            public string DatePrepared { get; set; } = string.Empty;
            public string LoanAmount { get; set; } = string.Empty;
            public string InterestRate { get; set; } = string.Empty;
            public string EffectiveYield { get; set; } = string.Empty;
            public string Term { get; set; } = string.Empty;
            public string Purpose { get; set; } = string.Empty;
            public string PurposeSpecify { get; set; } = string.Empty;
            public string TermDesired { get; set; } = string.Empty;
            public string Months { get; set; } = string.Empty;

            public string Vesting { get; set; } = string.Empty;

            public string EmploymentEmployer { get; set; } = string.Empty;

            public string EmployeeNumber { get; set; } = string.Empty;

            public string EmploymentPrePosition { get; set; } = string.Empty;

            public string EmploymentDept { get; set; } = string.Empty;

            public string EmploymentPlaceBranch { get; set; } = string.Empty;

            public string DateHired { get; set; } = string.Empty;

            public string Nationality { get; set; } = string.Empty;

            public string AppLengthService { get; set; } = string.Empty;

            public string AppMonthlySalary { get; set; } = string.Empty;

            public string EmploymentImmediateHead { get; set; } = string.Empty;

            public string EmploymentPositionHead { get; set; } = string.Empty;

            public string EmploymentTelnum { get; set; } = string.Empty;

            public string Sex { get; set; } = string.Empty;

            public string BirthDate { get; set; } = string.Empty;

            public string Status { get; set; } = string.Empty;

            public string BorrowerTelno { get; set; } = string.Empty;

            public string AppCellphone { get; set; } = string.Empty;

            public string BorrowerProvincialAdd { get; set; } = string.Empty;

            public string LengthStayPer { get; set; } = string.Empty;

            public string BorrowerAddress { get; set; } = string.Empty;

            public string LengthStapHome { get; set; } = string.Empty;

            public string ResidenceType { get; set; } = string.Empty;

            public string HowMuch { get; set; } = string.Empty;

            public string SpouseName { get; set; } = string.Empty;

            public string SpouseBirthDate { get; set; } = string.Empty;


            public string SpousePreEmp { get; set; } = string.Empty;

            public string SpouseAddress { get; set; } = string.Empty;

            public string SpouseLengthService { get; set; } = string.Empty;

            public string SpousePhone { get; set; } = string.Empty;

            public string SpousePrePos { get; set; } = string.Empty;

            public string SpouseSalary { get; set; } = string.Empty;

            public string NoChildren { get; set; } = string.Empty;

            public string YoungestChild { get; set; } = string.Empty;

            public string School { get; set; } = string.Empty;

            public string Course { get; set; } = string.Empty;

            public string SchoolYear { get; set; } = string.Empty;

            public string NearestRelative { get; set; } = string.Empty;

            public string RelativeAddress { get; set; } = string.Empty;

            public string Relationship { get; set; } = string.Empty;


            public string RelHomePhone { get; set; } = string.Empty;

            public string RelCellphone { get; set; } = string.Empty;

            public string BorrowerTin { get; set; } = string.Empty;

            public string BorrowerSSS { get; set; } = string.Empty;

            public string ResCertNo { get; set; } = string.Empty;

            public string PlaceIssue { get; set; } = string.Empty;

            public string DateIssue { get; set; } = string.Empty;

            public string Remarks { get; set; } = string.Empty;

            public string DocSubmitted { get; set; } = string.Empty;

            public string Tag { get; set; } = string.Empty;

            public string SourceApplication { get; set; } = string.Empty;

            public string Agent { get; set; } = string.Empty;

            public string Type { get; set; } = string.Empty;

            public string Agency { get; set; } = string.Empty;

            public string YearsOFW { get; set; } = string.Empty;

            public string Email { get; set; } = string.Empty;

            public string SpouseEmail { get; set; } = string.Empty;

            public string SourceIncome { get; set; } = string.Empty;

            public string SpouseSourceIncome { get; set; } = string.Empty;

            public string SpouseCitizenship { get; set; } = string.Empty;

            public string EmployeeStatus { get; set; } = string.Empty;

            public string EmployeeStatusOthers { get; set; } = string.Empty;






        }



        public class HappyPathForPNRequest
        {
            public string num { get; set; } = string.Empty;
            public string Acctnumber { get; set; } = string.Empty;
            public string Loannumber { get; set; } = string.Empty;
            public string DateSetup { get; set; } = string.Empty;
            public string DateAvailed { get; set; } = string.Empty;
            public string DateMaturity { get; set; } = string.Empty;
            public string LoanAmount { get; set; } = string.Empty;
            public string TotalInterest { get; set; } = string.Empty;
            public string TotalPrincipal { get; set; } = string.Empty;
            public string TotalBalance { get; set; } = string.Empty;
            public string InterestRate { get; set; } = string.Empty;
            public string Term { get; set; } = string.Empty;
            public string Rateperperiod { get; set; } = string.Empty;
            public string Typeofpayment { get; set; } = string.Empty;
            public string StatusAD { get; set; } = string.Empty;
            public string Computation { get; set; } = string.Empty;
            public string DocStamps { get; set; } = string.Empty;
            public string NotStamp { get; set; } = string.Empty;
            public string Service { get; set; } = string.Empty;
            public string ChattelMortgage { get; set; } = string.Empty;
            public string RealMortgage { get; set; } = string.Empty;
            public string Appraisal { get; set; } = string.Empty;
            public string OtherCharges { get; set; } = string.Empty;
            public string BrokenDayInterest { get; set; } = string.Empty;
            public string Setoff { get; set; } = string.Empty;
            public string CvNo { get; set; } = string.Empty;
            public string Instructions { get; set; } = string.Empty;
            public string ClassStatus { get; set; } = string.Empty;
            public string BrokenDay { get; set; } = string.Empty;
            public string Penalty { get; set; } = string.Empty;
            public string InterestUnpaid { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
            public string MNCTransferDate { get; set; } = string.Empty;
            public string Released { get; set; } = string.Empty;
            public string BrokenDayStart { get; set; } = string.Empty;
        }



        public class RetrieveInsertedHappyPathReponse
        {
            public int borrowerID { get; set; }

            public string borrowerNumber { get; set; } = string.Empty;

            public string lastName { get; set; } = string.Empty;

            public string firstName { get; set; } = string.Empty;

            public string middleName { get; set; } = string.Empty;

            public string suffixName { get; set; } = string.Empty;

            public int civilStatusId { get; set; }

            public DateTime birthdayOn { get; set; }

            public int applicationId { get; set; }

            public string applicationNumber { get; set; } = string.Empty;

            public DateTime valueOn { get; set; }

            public int productId { get; set; }

            public DateTime startOn { get; set; }

            public decimal principal { get; set; }

            public decimal interest { get; set; }

            public int term { get; set; }

            public int paymentCount { get; set; }

            public int interestOptionId { get; set; }

            public int loanTypeId { get; set; }

            public int paymentMethodId { get; set; }

            public int borroweridentifier { get; set; }

            public int userId { get; set; }

            public int accountId { get; set; }

            public string accountNumber { get; set; } = string.Empty;

            public string accountName { get; set; } = string.Empty;

            public decimal accountInterest { get; set; }

            public decimal accountPrincipal { get; set; }

            public DateTime accountsValueOn { get; set; }

            public decimal net { get; set; }

            public decimal balance { get; set; }

            public int accountStatusId { get; set; }

            


        }
    
    }
}
