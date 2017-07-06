using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace ClassLibrary
{
    public class Class_MedRec
    {
        #region Connection String Setup
        DataSet ds = new DataSet();
        static string conString = ValidateConnection.ConString();
        private static SqlConnection conn = new SqlConnection(conString);
        #endregion
        #region Variables
        private string patient_id, heart_rate, blood_sugar, blood_pressure, temperature, datetime, nurse_id;

        public string Nurse_id
        {
            get { return nurse_id; }
            set { nurse_id = value; }
        }

        public string Datetime
        {
            get { return datetime; }
            set { datetime = value; }
        }       

        public string Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        public string Blood_pressure
        {
            get { return blood_pressure; }
            set { blood_pressure = value; }
        }

        public string Blood_sugar
        {
            get { return blood_sugar; }
            set { blood_sugar = value; }
        }

        public string Heart_rate
        {
            get { return heart_rate; }
            set { heart_rate = value; }
        }

        

        public string Patient_id
        {
            get { return patient_id; }
            set { patient_id = value; }
        }
        #endregion

        public void insertNewMedRec()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert_MedRec", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = patient_id;            
            cmd.Parameters.Add("@Heart_Rate", SqlDbType.VarChar).Value = heart_rate;
            cmd.Parameters.Add("@Blood_Sugar", SqlDbType.VarChar).Value = blood_sugar;
            cmd.Parameters.Add("@Blood_Pressure", SqlDbType.VarChar).Value = blood_pressure;
            cmd.Parameters.Add("@Temperature", SqlDbType.VarChar).Value = temperature;
            cmd.Parameters.Add("@DateTime", SqlDbType.VarChar).Value = datetime;
            cmd.Parameters.Add("@Nurse_ID", SqlDbType.VarChar).Value = nurse_id;
            
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public DataSet viewMedRecDetails()
        {
            SqlCommand cmd = new SqlCommand("select_MedRec", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = patient_id;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds, "select_MedRec");
            return ds;
        }
    }
}
