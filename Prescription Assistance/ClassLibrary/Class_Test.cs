using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class Class_Test
    {
        #region Connection String Setup
        DataSet ds = new DataSet();
        static string conString = ValidateConnection.ConString();
        private static SqlConnection conn = new SqlConnection(conString);
        #endregion

        public void insertFile(string filename, string patientid, byte[] file)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert_Test", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = patientid;
            cmd.Parameters.Add("@Test_File", SqlDbType.VarBinary).Value = file;
            cmd.Parameters.Add("@Test_Filename", SqlDbType.VarChar).Value = filename;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public DataSet selectTest(string id)
        {
            SqlCommand cmd = new SqlCommand("select_Test", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = id;    
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds, "select_Test");
            return ds;
        }

        public byte[] selectTestFile(string id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select_TestFile", conn);
            cmd.Parameters.Add("@Test_ID", SqlDbType.VarChar).Value = id;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            byte[] buffer = (byte[])cmd.ExecuteScalar();
            conn.Close();
            return buffer;
        }
    }
}
