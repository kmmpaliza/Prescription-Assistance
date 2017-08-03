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
        private string alert_id, type, bed_id, info_id, status, timefordisplay, timeforsms, ondisplay;

        public string Ondisplay
        {
            get { return ondisplay; }
            set { ondisplay = value; }
        }

        public string Timeforsms
        {
            get { return timeforsms; }
            set { timeforsms = value; }
        }

        public string Timefordisplay
        {
            get { return timefordisplay; }
            set { timefordisplay = value; }
        }

        public string Info_id
        {
            get { return info_id; }
            set { info_id = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
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
        string id;

        public DataSet viewUnfinishedAlerts(string types)
        {
            SqlCommand cmd = new SqlCommand("select_Alert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = types;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds, "select_Alert");
            return ds;
        }

        public DataSet viewLateAlerts()
        {
            SqlCommand cmd = new SqlCommand("select_LateAlerts", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds, "select_LateAlerts");
            return ds;
        }

        public string insertAlert()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert_Alert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = type;
            cmd.Parameters.Add("@Bed_ID", SqlDbType.VarChar).Value = bed_id;
            cmd.Parameters.Add("@Info_ID", SqlDbType.VarChar).Value = info_id;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;
            cmd.Parameters.Add("@TimeforDisplay", SqlDbType.VarChar).Value = timefordisplay;
            cmd.Parameters.Add("@TimeforSMS", SqlDbType.VarChar).Value = timeforsms;
            cmd.Parameters.Add("@OnDisplay", SqlDbType.VarChar).Value = ondisplay;
            //cmd.ExecuteNonQuery();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id = dr[0].ToString();
                break;
            }
            conn.Close();

            return id;
        }

        public void updateAlert()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update_Alert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Alert_ID", SqlDbType.VarChar).Value = alert_id;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;
            cmd.Parameters.Add("@TimeforDisplay", SqlDbType.VarChar).Value = timefordisplay;
            cmd.Parameters.Add("@TimeforSMS", SqlDbType.VarChar).Value = timeforsms;
            cmd.Parameters.Add("@OnDisplay", SqlDbType.VarChar).Value = ondisplay;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
