using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class Class_Patient
    {
        #region Connection String Setup
        DataSet ds = new DataSet();
        static string conString = ValidateConnection.ConString();
        private static SqlConnection conn = new SqlConnection(conString);
        #endregion
        #region Variables
        private string last_name, first_name, gender, age, birthday, address, contact, room_id, bed_id, patient_id;

        public string Address
        {
            get { return address; }
            set { address = value; }
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

        public string Room_id
        {
            get { return room_id; }
            set { room_id = value; }
        }

        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        public string Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string First_name
        {
            get { return first_name; }
            set { first_name = value; }
        }

        public string Last_name
        {
            get { return last_name; }
            set { last_name = value; }
        }

        #endregion
        string id;

        public DataSet viewAllPatients()
        {
            SqlCommand cmd = new SqlCommand("select_AllPatient", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds, "select_AllPatient");
            return ds; 
        }

        public DataSet viewPatientDetails()
        {
            SqlCommand cmd = new SqlCommand("select_Patient", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = patient_id;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds, "select_Patient");
            return ds;    
        }

        public DataSet searchPatient()
        {
            SqlCommand cmd = new SqlCommand("search_Patient", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = patient_id;
            cmd.Parameters.Add("@First_name", SqlDbType.VarChar).Value = first_name;
            cmd.Parameters.Add("@Last_name", SqlDbType.VarChar).Value = last_name;
            cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = gender;
            cmd.Parameters.Add("@Age", SqlDbType.VarChar).Value = age;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@Contact", SqlDbType.VarChar).Value = contact;
            cmd.Parameters.Add("@Birthday", SqlDbType.VarChar).Value = birthday;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds, "search_Patient");
            return ds;
        }

        public string insertNewPatient()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert_Patient", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@First_name", SqlDbType.VarChar).Value = first_name;
            cmd.Parameters.Add("@Last_name", SqlDbType.VarChar).Value = last_name;
            cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = gender;
            cmd.Parameters.Add("@Age", SqlDbType.VarChar).Value = age;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@Contact", SqlDbType.VarChar).Value = contact;
            cmd.Parameters.Add("@Birthday", SqlDbType.VarChar).Value = birthday;
            cmd.Parameters.Add("@Room_ID", SqlDbType.VarChar).Value = room_id;
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

        public void updatePatient()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update_Patient", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = patient_id;
            cmd.Parameters.Add("@First_name", SqlDbType.VarChar).Value = first_name;
            cmd.Parameters.Add("@Last_name", SqlDbType.VarChar).Value = last_name;
            cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = gender;
            cmd.Parameters.Add("@Age", SqlDbType.VarChar).Value = age;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@Contact", SqlDbType.VarChar).Value = contact;
            cmd.Parameters.Add("@Birthday", SqlDbType.VarChar).Value = birthday;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
