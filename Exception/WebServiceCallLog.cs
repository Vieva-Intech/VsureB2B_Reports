using System.Text;
using VSureB2b_Reports.BO;
namespace VSureB2b_Reports.Exception
{
    public class WebServiceCallLog
    {
        static FileStream fs;
        static StreamWriter sw;
        static StringBuilder message;
        static int replicateCnt;
        static string logFilePath, saveLogFile;
        private readonly IConfiguration _configuration;

        public WebServiceCallLog(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static StringBuilder ServiceLog(string WebService, Dictionary<string, string> dic)
        {
            // logFilePath = System.Configuration.ConfigurationSettings.AppSettings["WebServiceLogFilePath"].ToString();
            fs = File.Open(logFilePath, FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            replicateCnt = 130;

            FileInfo file = new FileInfo(logFilePath);
            DateTime lastAccess = file.LastWriteTime;

            int index = logFilePath.IndexOf(".");
            string name = logFilePath.Remove(index);

            if (lastAccess.ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                sw.Close();
                File.Move(logFilePath, name + lastAccess.Year + "_" + lastAccess.Month + "_" + lastAccess.Day + ".log");
                fs = File.Open(logFilePath, FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            }

            message = new StringBuilder();

            message.Append('-', replicateCnt);
            message.AppendLine("");
            message.AppendLine("Intimate   :" + DateTime.Now.ToString());
            message.AppendLine("WebService :" + WebService);
            message.Append("Parameters :");

            int parameterCount = dic.Count;
            int cnt = 0;
            foreach (var d in dic)
            {
                cnt++;
                message.Append(d.Key + ": ");
                message.Append(d.Value);
                if (cnt < parameterCount)
                    message.Append(" |  ");
            }
            message.AppendLine("");

            if (WebService == "ExportClaim")
                sw.WriteLine(message);

            return message;
        }

        public void CreateWebServiceLogFile(string WebService, Dictionary<string, string> dic, string ReturnValue)
        {
            //To Do:03-09-2012
            //Log in database
            //saveLogFile = System.Configuration.ConfigurationSettings.AppSettings["SaveWebServiceLog"].ToString();

            var saveLogFile = _configuration["appSettings:SaveWebServiceLog"];
            if (saveLogFile == "Database")
                DbWebServiceLogFile(WebService, dic, ReturnValue);
            else
            {
                message = ServiceLog(WebService, dic);

                message.AppendLine("Return     :" + ReturnValue);
                message.Append('-', replicateCnt);
                message.AppendLine("");

                sw.WriteLine(message);
                sw.Close();
            }
        }
        public static void DbWebServiceLogFile(string WebService, Dictionary<string, string> dic, string ReturnValue)
        {
            string msg = GetParameterList(dic);

            WebServiceLog webServiceLog = new WebServiceLog
            {
                WebService = WebService,
                Parameter = msg,
                Intimate = DateTime.Now,
                ReturnValue = ReturnValue,
                CallerIPAddress = null,
                Remarks = null
            };
            webServiceLog.Save();
        }
        public static string GetParameterList(Dictionary<string, string> dic)
        {
            string paraString = string.Empty;
            int parameterCount = dic.Count;
            int cnt = 0;
            foreach (var d in dic)
            {
                cnt++;
                paraString += d.Key + ":";
                paraString += d.Value;
                if (cnt < parameterCount)
                    paraString += " | ";
            }
            return paraString;
        }
    }
}
