using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class Class_Vitals
    {
        #region Connection String Setup
        DataSet ds = new DataSet();
        static string conString = ValidateConnection.ConString();
        private static SqlConnection conn = new SqlConnection(conString);
        #endregion
        #region Variables
        private string vital_id, patient_id, status, bed_id;

        public string Bed_id
        {
            get { return bed_id; }
            set { bed_id = value; }
        }

        public string Patient_id
        {
            get { return patient_id; }
            set { patient_id = value; }
        }

        public string Vital_id
        {
            get { return vital_id; }
            set { vital_id = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        #endregion
        string id;

        public DataSet viewVital()
        {
            SqlCommand cmd = new SqlCommand("select_Vital", conn);
            cmd.Parameters.Add("@Vital_ID", SqlDbType.VarChar).Value = vital_id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds, "select_Vital");
            return ds;
        }

        public string insertVital()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert_Vital", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = patient_id;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;
            cmd.Parameters.Add("@Bed_ID", SqlDbType.VarChar).Value = bed_id;
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

        public void updateVital()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update_Vital", conn);
            cmd.Parameters.Add("@Vital_ID", SqlDbType.VarChar).Value = vital_id;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
