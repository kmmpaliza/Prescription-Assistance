using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class Class_Prescription
    {
        #region Connection String Setup
        DataSet ds = new DataSet();
        static string conString = ValidateConnection.ConString();
        private static SqlConnection conn = new SqlConnection(conString);
        #endregion
        #region Variables
        private string prescription_id, patient_id, medicine_name, dosage, route, form, interval, note;

        public string Prescription_id
        {
            get { return prescription_id; }
            set { prescription_id = value; }
        }

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        public string Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        public string Form
        {
            get { return form; }
            set { form = value; }
        }

        public string Route
        {
            get { return route; }
            set { route = value; }
        } 

        public string Dosage
        {
            get { return dosage; }
            set { dosage = value; }
        }

        public string Medicine_name
        {
            get { return medicine_name; }
            set { medicine_name = value; }
        }

        public string Patient_id
        {
            get { return patient_id; }
            set { patient_id = value; }
        }
        #endregion

        public DataSet viewPescriptionDetails()
        {
            SqlCommand cmd = new SqlCommand("select_Prescription", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = patient_id;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds, "select_Prescription");
            return ds;    
        }

        public void insertNewPrescription()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert_Prescription", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = patient_id;
            cmd.Parameters.Add("@Medicine_Name", SqlDbType.VarChar).Value = medicine_name;
            cmd.Parameters.Add("@Dosage", SqlDbType.VarChar).Value = dosage;
            cmd.Parameters.Add("@Route", SqlDbType.VarChar).Value = route;
            cmd.Parameters.Add("@Form", SqlDbType.VarChar).Value = form;
            cmd.Parameters.Add("@Interval", SqlDbType.VarChar).Value = interval;
            cmd.Parameters.Add("@Note", SqlDbType.VarChar).Value = note;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void updatePrescription()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update_Prescription", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Prescription_ID", SqlDbType.VarChar).Value = prescription_id;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = patient_id;
            cmd.Parameters.Add("@Medicine_Name", SqlDbType.VarChar).Value = medicine_name;
            cmd.Parameters.Add("@Dosage", SqlDbType.VarChar).Value = dosage;
            cmd.Parameters.Add("@Route", SqlDbType.VarChar).Value = route;
            cmd.Parameters.Add("@Form", SqlDbType.VarChar).Value = form;
            cmd.Parameters.Add("@Interval", SqlDbType.VarChar).Value = interval;
            cmd.Parameters.Add("@Note", SqlDbType.VarChar).Value = note;
            cmd.ExecuteNonQuery();

            conn.Close(); 
        }

        public void deletePrescription()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete_Prescription", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Prescription_ID", SqlDbType.VarChar).Value = prescription_id;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = patient_id;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
