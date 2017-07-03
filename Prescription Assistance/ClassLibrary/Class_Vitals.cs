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
        private string vital_id, patient_id, status;

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

        public void insertVital()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert_Vital", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = patient_id;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = status;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
