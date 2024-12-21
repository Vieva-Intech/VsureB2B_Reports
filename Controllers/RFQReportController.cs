using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logging;
using Newtonsoft.Json.Linq;

using static Logging.Log;
using Microsoft.Extensions.Configuration;
using VSureB2b_Reports.Control;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Text.RegularExpressions;
using VSureB2b_Reports.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using VSureB2b_Reports.ImportExport;
using VSureB2b_Reports.Exception;
using Microsoft.AspNetCore.Http.HttpResults;
//using VSureB2b_Reports.BO;
using Azure.Core;
using Amazon.Runtime.Internal;

namespace VSureB2b_Reports.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RFQReportController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public string connectionString;
        private readonly WebAPIManager _webAPIManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        // private readonly ILogger<DataController> _logger;
        //  WebAPIManager WebAPIManager;

        public RFQReportController(IConfiguration configuration, WebAPIManager webAPIManager, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _webAPIManager = webAPIManager;
            _httpContextAccessor = httpContextAccessor;
            Log.BaseDirectory = _configuration.GetValue<string>("Data:" + "LogDirectory");
            Log.DataBaseLog = _configuration.GetValue<string>("Data:" + "DataBaseLog");
            Log.Async = _configuration.GetValue<string>("Async");
            Log.connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public static bool CheckURL(string input)
        {
            if (input.Contains("..") || input.Contains("../") || input.Contains(",") || input.Contains("===") || input.Contains("==") || input.Contains("/..") || input.Contains("/.") || input.Contains("./"))//|| input.Contains("/") 
            {
                return true;
            }

            return false;
        }


        [HttpPost]
        [ApiVersionNeutral]
        [Route("GetRFQReport")]
        public IActionResult GetRFQReport([FromBody] RFQRequestModel request)
        {
            string url = _httpContextAccessor.HttpContext.Request.GetDisplayUrl();
            bool isCorruptedUrl = CheckURL(url);
            if (isCorruptedUrl)
            {
                return BadRequest("Corrupted URL");
            }

            try
            {
                Log.BaseDirectory = _configuration.GetValue<string>("Data:LogDirectory");

                // Call the Web API Manager to execute the stored procedure
                var response = _webAPIManager.GetRFQReport(request);

                // Return the result as a JSON response
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                Log.Write("Error in GetRFQReport API: " + ex.Message + ex.StackTrace);
                return StatusCode(500, "Internal server error while fetching RFQ report.");
            }
        }
    }
}
