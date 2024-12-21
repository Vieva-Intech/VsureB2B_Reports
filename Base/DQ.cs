using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;
using VSureB2b_Reports.ImportExport;

namespace VSureB2b_Reports.Base
{
    public class DQ
    {
        public DbCommand Command { get; }
        public DbConnection Connection { get; }
        public DQ() : base()
        {
            //if (Connection.State == ConnectionState.Open)

            //    Connection.Close();


            //TODO: Add constructor logic here
            if (Connection != null && Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }

            // Initialize the connection if it's not already initialized
            if (Connection == null)
            {
                Connection = new SqlConnection(Utility1.vsureb2bconnectionstring);
            }


        }
        public DQ(DbCommand CurrentCommand)
        {
        }
        public object ExecuteScalar(string query)
        {
            using (SqlConnection connection = new SqlConnection(Utility1.vsureb2bconnectionstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }
        //public DataSet Load(Boolean showAddRecord)
        //{
        //    DataSet ds = base.Load();
        //    if (showAddRecord)
        //        AddInsertRow(ds.Tables[0]);
        //    return ds;
        //}
        //public DataTable LoadTable(Boolean showAddRecord)
        //{
        //    DataTable dt = base.LoadTable();
        //    if (showAddRecord)
        //        AddInsertRow(dt);
        //    return dt;
        //}

        public void AddInsertRow(DataTable dt)
        {
            dt.Rows.InsertAt(dt.NewRow(), 0);
        }
    }
}
