using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class Class_Alert
    {
        #region Connection String Setup
        DataSet ds = new DataSet();
        static string conString = ValidateConnection.ConString();
        private static SqlConnection conn = new SqlConnection(conString);
        #endregion
        #region Variables
        private string alert_id, bed_id, assistance, status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Assistance
        {
            get { return assistance; }
            set { assistance = value; }
        }

        public string Bed_id
        {
            get { return bed_id; }
            set { bed_id = value; }
        }

        public string Alert_id
        {
            get { return alert_id; }
            set { alert_id = value; }
        }

        #endregion

        public DataSet viewUnfinishedAlerts()
        {
            SqlCommand cmd = new SqlCommand("select_Alert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds, "select_Alert");
            return ds;
        }

        public void insertAlert()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert_Alert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Bed_ID", SqlDbType.VarChar).Value = bed_id;
            cmd.Parameters.Add("@Assistance", SqlDbType.VarChar).Value = assistance;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void updateAlertStatus()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update_Alert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Alert_ID", SqlDbType.VarChar).Value = alert_id;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
