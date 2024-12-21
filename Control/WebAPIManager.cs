using Logging;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Data;
using System.Xml;
using ThirdParty.Json.LitJson;
using VSureB2b_Reports.BO;
using VSureB2b_Reports.ImportExport;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using System;
using VSureB2b_Reports.Control;
using System.Net.Http;
using Logging;
using static Logging.Log;
using System.Text.RegularExpressions;
using System.Text;
using VSureB2b_Reports.Facades;
using VSureB2b_Reports.Base;
using System.Collections;
using System.Web;
using VSureB2b_Reports;
using Microsoft.AspNetCore.Http.HttpResults;
using Dapper;
using VSureB2b_Reports.Models;
using Azure.Core;
using System.Globalization;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
//using VSureB2b_Reports.Base;
using System.Data.Common;


namespace VSureB2b_Reports.Control
{
    public class WebAPIManager
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string company;
        private readonly string CCM;
        public static SqlConnection sqlConnection = new SqlConnection();
        private static string _ConString;
        public static string ConString { get => _ConString; set => _ConString = value; }

        public WebAPIManager(IConfiguration configuration, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public Dictionary<string, int> dictionary = null;
        string returnValue = string.Empty;
        int dictionarycount = 0;

        protected decimal? isDecimal(string value)
        {
            decimal? returnDecimal = null;
            decimal _Decimal;
            if (decimal.TryParse(value, out _Decimal))
            {
                returnDecimal = _Decimal;
            }
            return returnDecimal;


        }
        protected DateTime? isDateTime(string value)
        {
            DateTime? dt = null;
            DateTime dv = DateTime.Now;
            if (DateTime.TryParse(value, out dv))
            {
                return dv;
            }
            else
            {
                return null;
            }

        }

        // added by sundus


        public string GetRFQReport(RFQRequestModel request)
        {
            try
            {
                // Extract parameters from the request
                string period = request.Period;
                string type = request.Type;

                int? year = request.Year;          // Use as-is; don't set a default
                DateTime? date = request.Date;     // Use as-is; don't set a default

                // Explicitly set Date to NULL for YTD
                if (period.Equals("YTD", StringComparison.OrdinalIgnoreCase))
                {
                    date = null;
                }

                // Call the method from SurveyanceClaimFacade to execute the stored procedure
                var result = VSureb2bFacade.GetRFQReport(period, type, year, date);

                if (result != null && result.Rows.Count > 0)
                {
                    var responseList = result.AsEnumerable()
                        .Select(row => new RFQResponseModel
                        {
                            Period = row.Field<string>("Period"),
                            Type = row.Field<string>("Type"),
                            TotalRFQs = row.Field<int>("TotalRFQs"),
                            TotalAmount = row.Field<decimal>("TotalAmount")
                        }).ToList();

                    return JsonConvert.SerializeObject(responseList);
                }

                // Return a message if no data is found
                return JsonConvert.SerializeObject(new { message = "No data found for the given parameters." });
            }
            catch (System.Exception ex)
            {
                Log.Write("Error in GetRFQReport: " + ex.Message + ex.StackTrace);

                // Return a generic error message
                return JsonConvert.SerializeObject(new { message = "Error occurred while fetching the RFQ report." });
            }
        }
    }
}
