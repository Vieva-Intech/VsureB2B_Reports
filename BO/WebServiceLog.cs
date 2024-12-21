using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using VSureB2b_Reports.ImportExport;

namespace VSureB2b_Reports.BO
{
    public class WebServiceLog
    {
        int _Id;
        string _WebService;
        string _Parameter;
        DateTime? _Intimate;
        string _ReturnValue;
        string _ErrorOccurred;
        string _CallerIPAddress;
        string _Remarks;
        bool _IsNew;

        #region Properties

        public int Id
        {
            get { return _Id; }
        }

        public string WebService
        {
            get { return _WebService; }
            set { _WebService = value; }
        }

        public string Parameter
        {
            get { return _Parameter; }
            set { _Parameter = value; }
        }

        public DateTime? Intimate
        {
            get { return _Intimate; }
            set { _Intimate = value; }
        }

        public string ReturnValue
        {
            get { return _ReturnValue; }
            set { _ReturnValue = value; }
        }

        public string ErrorOccurred
        {
            get { return _ErrorOccurred; }
            set { _ErrorOccurred = value; }
        }

        public string CallerIPAddress
        {
            get { return _CallerIPAddress; }
            set { _CallerIPAddress = value; }
        }

        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        public bool IsNew
        {
            get { return _IsNew; }
            set { _IsNew = value; }
        }

        #endregion

        public virtual bool Save()
        {
            if (this.IsNew)
                return Insert();
            else
                return Update();
        }
        SqlConnection con = new SqlConnection(Utility1.vsureb2bconnectionstring);
        public bool Insert()
        {
            //Database db = DatabaseFactory.CreateDatabase();
            //string sqlCommand = "Add_WebServiceLog";

            //DBCommandWrapper dbCommandWrapper = db.GetStoredProcCommandWrapper(sqlCommand);
            //dbCommandWrapper.AddInParameter("WebService", DbType.AnsiString, SetNullValue((_WebService == string.Empty), _WebService));
            //dbCommandWrapper.AddInParameter("Parameter", DbType.AnsiString, SetNullValue((_Parameter == string.Empty), _Parameter));
            //dbCommandWrapper.AddInParameter("Intimate", DbType.DateTime, SetNullValue((_Intimate == DateTime.MinValue), _Intimate));
            //dbCommandWrapper.AddInParameter("ReturnValue", DbType.AnsiString, SetNullValue((_ReturnValue == string.Empty), _ReturnValue));
            //dbCommandWrapper.AddInParameter("ErrorOccurred", DbType.AnsiString, SetNullValue((_ErrorOccurred == string.Empty), _ErrorOccurred));
            //dbCommandWrapper.AddInParameter("CallerIPAddress", DbType.AnsiString, SetNullValue((_CallerIPAddress == string.Empty), _CallerIPAddress));
            //dbCommandWrapper.AddInParameter("Remarks", DbType.AnsiString, SetNullValue((_Remarks == string.Empty), _Remarks));
            //db.ExecuteNonQuery(dbCommandWrapper);

            SqlCommand cmd = new SqlCommand
            {
                CommandText = "Add_WebServiceLog",
                CommandType = CommandType.StoredProcedure,
                Connection = con
            };
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            cmd.Parameters.AddWithValue("WebService", _WebService);
            cmd.Parameters.AddWithValue("Parameter", _Parameter);
            cmd.Parameters.AddWithValue("Intimate", _Intimate);
            cmd.Parameters.AddWithValue("ReturnValue", _ReturnValue);
            cmd.Parameters.AddWithValue("ErrorOccurred", _ErrorOccurred);
            cmd.Parameters.AddWithValue("CallerIPAddress", _CallerIPAddress);
            cmd.Parameters.AddWithValue("Remarks", _Remarks);
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool Update()
        {
            using (SqlCommand cmd = new SqlCommand("Update_WebServiceLog", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", _Id);
                cmd.Parameters.AddWithValue("WebService", _WebService ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("Parameter", _Parameter ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("Intimate", _Intimate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("ReturnValue", _ReturnValue ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("ErrorOccurred", _ErrorOccurred ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("CallerIPAddress", _CallerIPAddress ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("Remarks", _Remarks ?? (object)DBNull.Value);

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                cmd.ExecuteNonQuery();
            }

            return true;

        }
        public static void DbWebServiceLogFile(string WebService, string content, string ReturnValue, string ex, string ip, string Remarks)
        {
            WebServiceLog webServiceLog = new WebServiceLog
            {
                WebService = WebService,
                Parameter = content,
                Intimate = DateTime.Now,
                ReturnValue = ReturnValue,
                ErrorOccurred = ex,
                CallerIPAddress = ip,
                Remarks = Remarks
            };
            webServiceLog.Save();
        }
    }
}
