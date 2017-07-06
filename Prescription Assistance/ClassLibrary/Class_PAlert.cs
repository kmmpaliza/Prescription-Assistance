using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class Class_PAlert
    {
        #region Connection String Setup
        DataSet ds = new DataSet();
        static string conString = ValidateConnection.ConString();
        private static SqlConnection conn = new SqlConnection(conString);
        #endregion
        #region Variables
        private string palert_id, bed_id, patient_id, prescription_id, time, status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public string Prescription_id
        {
            get { return prescription_id; }
            set { prescription_id = value; }
        }

        public string Patient_id
        {
            get { return patient_id; }
            set { patient_id = value; }
        }

        public string Bed_id
        {
            get { return bed_id; }
            set { bed_id = value; }
        }

        public string Palert_id
        {
            get { return palert_id; }
            set { palert_id = value; }
        }

     

        #endregion

        public DataSet viewPAlert()
        {
            SqlCommand cmd = new SqlCommand("select_PAlert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PAlert_ID", SqlDbType.VarChar).Value = palert_id;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds, "select_PAlert");
            return ds;
        }

        public DataSet viewUndonePalerts()
        {
            SqlCommand cmd = new SqlCommand("select_UndonePalerts", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds, "select_UndonePalerts");
            return ds;
        }

        public void insertPAlert()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert_PAlert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Bed_ID", SqlDbType.VarChar).Value = bed_id;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = patient_id;
            cmd.Parameters.Add("@Prescription_ID", SqlDbType.VarChar).Value = prescription_id;
            cmd.Parameters.Add("@Time", SqlDbType.VarChar).Value = time;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void updatePAlert()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update_PAlert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PAlert_ID", SqlDbType.VarChar).Value = palert_id;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
