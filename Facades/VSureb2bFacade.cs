using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.Common;
using VSureB2b_Reports.Base;
using VSureB2b_Reports.BO;
using VSureB2b_Reports.ImportExport;

namespace VSureB2b_Reports.Facades 
{
    public class VSureb2bFacade : VSureb2b
    {
        #region Constructors
        public VSureb2bFacade() { }
        public VSureb2bFacade(DbCommand CurrentCommand)
        {
            this.Query = new DQ(CurrentCommand);
            this.Clear();
        }

        //public VSureb2bFacade(DbCommand CurrentCommand, string ClaimNo)
        //{
        //    this.Query = new DQ(CurrentCommand);
        //    this.Load(ClaimNo);
        //}
        #endregion Constructors

        public static DataTable GetRFQReport(string period, string type, int? year, DateTime? date = null)
        {
            DataSet ds = new DataSet();

            using (SqlConnection sqlConnection = new SqlConnection(Utility1.vsureb2bconnectionstring))
            using (SqlCommand sqlCommand = new SqlCommand("GetRFQ_Details_MTD_YTD", sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Add parameters to the stored procedure
                sqlCommand.Parameters.AddWithValue("@Period", period);
                sqlCommand.Parameters.AddWithValue("@Type", type);
                sqlCommand.Parameters.AddWithValue("@Year", (object)year ?? DBNull.Value);

                // Validate and enforce the Date requirement based on Period
                if (period == "YTD")
                {
                    sqlCommand.Parameters.AddWithValue("@Date", DBNull.Value); // Date is explicitly NULL for YTD
                }
                else if (period == "MTD" && date.HasValue)
                {
                    sqlCommand.Parameters.AddWithValue("@Date", date.Value); // Date must be provided for MTD
                }
                else
                {
                    throw new ArgumentException("Date must be provided for MTD period.");
                }

                // Execute the stored procedure and fill the DataSet
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds);

                return ds.Tables[0];
            }
        }
    }
}
