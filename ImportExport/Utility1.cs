using Logging;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Data;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace VSureB2b_Reports.ImportExport
{
    public class Utility1
    {
         private static IConfiguration _configuration;
        public Metadata1 MetaData;

        public Templatedata1 Templatedata;
        public TransportType1 TransportType;
        public AddressTo1 AddressTo;
        public const string EDPassword = "TDES2006YWR";

        public static void Configure(IConfiguration configuration)
        {
            _configuration = configuration;
        }

       

        public static string Debug
        {
            get
            {
                try
                {
                    string con = _configuration.GetValue<string>("Data:"+"Debug");
                    return con;
                }
                catch (System.Exception ex)
                {
                    Log.Write(2, ex.ToString());
                    throw ex;
                }
            }
        }

        public static string vsureb2bconnectionstring
        {
            get
            {
                try
                {
                    if (_configuration == null)
                    {
                        throw new InvalidOperationException("Configuration has not been initialized. Call Initialize method with a valid IConfiguration instance.");
                    }

                    string con = _configuration.GetConnectionString("vsureb2bconnectionstring");
                    return con;
                }
                catch (System.Exception ex)
                {
                    Log.Write(2, ex.ToString());
                    // Log or handle the exception as needed
                    throw new System.Exception("An error occurred while getting the connection string.", ex);
                }
            }
        }


        public class Metadata1
        {
            public string ClaimNo;
            public string PolicyId;
        }
        public class Templatedata1
        {
            public string Surveyor_Name;
            public string Surveyor_Number;
            public string Product_Name;
            public string Customer_Name;
            public string Payee_Name;
            public decimal? Claim_Amount;
            public string UTR_No;
            public string Vehicle_No;
            public decimal? Repair_Amount;
            public string isAttachmentRequired;
            public string Claim_Handler_Name;
            public string Claim_Handler_No;
        }
        public class TransportType1
        {
            public string SourceId;
            public string InteractionId;
            public string Identifier;
            public string TemplateId;
        }
        public class AddressTo1
        {
            public string SMSMobileNumber;
            public string[] EmailTo;
            public string[] EmailCc;
            public string[] EmailBcc;
            public string EmailFrom;
        }
    }
}
