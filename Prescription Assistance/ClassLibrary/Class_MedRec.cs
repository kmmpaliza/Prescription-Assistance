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
        private string patient_id, weight, height, heart_rate, blood_sugar, blood_pressure, temperature, medical_history, medical_findings, special_instructions;

        public string Medical_findings
        {
            get { return medical_findings; }
            set { medical_findings = value; }
        }

        public string Special_instructions
        {
            get { return special_instructions; }
            set { special_instructions = value; }
        }

        public string Medical_history
        {
            get { return medical_history; }
            set { medical_history = value; }
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

        public string Height
        {
            get { return height; }
            set { height = value; }
        }

        public string Weight
        {
            get { return weight; }
            set { weight = value; }
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
            cmd.Parameters.Add("@Weight", SqlDbType.VarChar).Value = weight;
            cmd.Parameters.Add("@Height", SqlDbType.VarChar).Value = height;
            cmd.Parameters.Add("@Heart_Rate", SqlDbType.VarChar).Value = heart_rate;
            cmd.Parameters.Add("@Blood_Sugar", SqlDbType.VarChar).Value = blood_sugar;
            cmd.Parameters.Add("@Blood_Pressure", SqlDbType.VarChar).Value = blood_pressure;
            cmd.Parameters.Add("@Temperature", SqlDbType.VarChar).Value = temperature;
            cmd.Parameters.Add("@Medical_History", SqlDbType.VarChar).Value = medical_history;
            cmd.Parameters.Add("@Medical_Findings", SqlDbType.VarChar).Value = medical_findings;
            cmd.Parameters.Add("@Special_Instructions", SqlDbType.VarChar).Value = special_instructions;
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

        public void updateMedRec()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("update_MedRecAsNurse", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = patient_id;
            cmd.Parameters.Add("@Weight", SqlDbType.VarChar).Value = weight;
            cmd.Parameters.Add("@Height", SqlDbType.VarChar).Value = height;
            cmd.Parameters.Add("@Heart_Rate", SqlDbType.VarChar).Value = heart_rate;
            cmd.Parameters.Add("@Blood_Sugar", SqlDbType.VarChar).Value = blood_sugar;
            cmd.Parameters.Add("@Blood_Pressure", SqlDbType.VarChar).Value = blood_pressure;
            cmd.Parameters.Add("@Temperature", SqlDbType.VarChar).Value = temperature;
            cmd.Parameters.Add("@Medical_History", SqlDbType.VarChar).Value = medical_history;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void updateMedRecDoctor()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("update_MedRecAsDoctor", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = patient_id;
            cmd.Parameters.Add("@Medical_Findings", SqlDbType.VarChar).Value = medical_findings;
            cmd.Parameters.Add("@Special_Instructions", SqlDbType.VarChar).Value = special_instructions;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
