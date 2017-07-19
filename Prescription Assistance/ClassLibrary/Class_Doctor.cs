using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace ClassLibrary
{
    public class Class_Doctor
    {
        #region Connection String Setup
        DataSet ds = new DataSet();
        static string conString = ValidateConnection.ConString();
        private static SqlConnection conn = new SqlConnection(conString);
        #endregion
        #region Variables
        private string last_name, first_name, password, doctor_id, contact;

        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        public string Doctor_id
        {
            get { return doctor_id; }
            set { doctor_id = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
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

        public DataSet viewDoctorDetails()
        {
            SqlCommand cmd = new SqlCommand("select_Doctor", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Doctor_ID", SqlDbType.VarChar).Value = doctor_id;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds, "select_Doctor");
            return ds;
        }

        public string insertNewDoctor()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert_Doctor", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@First_name", SqlDbType.VarChar).Value = first_name;
            cmd.Parameters.Add("@Last_name", SqlDbType.VarChar).Value = last_name;
            cmd.Parameters.Add("@Contact", SqlDbType.VarChar).Value = contact;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
            //cmd.ExecuteNonQuery();
            //conn.Close();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id = dr[0].ToString();
                break;
            }
            conn.Close();

            return id;
        }

        public void updateDoctor()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update_Doctor", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Doctor_ID", SqlDbType.VarChar).Value = doctor_id;
            cmd.Parameters.Add("@First_name", SqlDbType.VarChar).Value = first_name;
            cmd.Parameters.Add("@Last_name", SqlDbType.VarChar).Value = last_name;
            cmd.Parameters.Add("@Contact", SqlDbType.VarChar).Value = contact;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
