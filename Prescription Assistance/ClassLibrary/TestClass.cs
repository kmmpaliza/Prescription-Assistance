using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class TestClass
    {
        #region Connection String Setup
        DataSet ds = new DataSet();
        static string conString = ValidateConnection.ConString();
        private static SqlConnection conn = new SqlConnection(conString);
        #endregion

        public void insertFile(string testid, string patientid, byte[] file)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insertTest", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Test_ID", SqlDbType.VarChar).Value = testid;
            cmd.Parameters.Add("@Patient_ID", SqlDbType.VarChar).Value = patientid;
            cmd.Parameters.Add("@Test_File", SqlDbType.VarBinary).Value = file;
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public byte[] selectTest(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("selectTest", conn);
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = id;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            byte[] buffer = (byte[])cmd.ExecuteScalar();
            conn.Close();
            return buffer;
        }
    }
}
