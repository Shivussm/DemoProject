using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Management;

namespace DemoProject.Models
{
    public class DataLayer
    {
        string connectionstring = ("Data Source=sharedmssql10.znetindia.net,1234;Initial Catalog=Jaymaasailani;Persist Security Info=True;User ID=Jaymaa;Password=Nde3c^052");

        public bool Contact(ContactModal contactModal)
        {
            {
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("Proc_InsertContact", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", contactModal.Name);
                cmd.Parameters.AddWithValue("@Email", contactModal.Email);
                cmd.Parameters.AddWithValue("@Subject", contactModal.Subject);
                cmd.Parameters.AddWithValue("@Message", contactModal.Message);
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@IsActive", 1);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                conn.Close();
            }


        }

        //public DataTable executewithparameter(string procedure, SqlParameter[] parameters)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionstring))
        //    {

        //        using (SqlCommand cmd = new SqlCommand(procedure, conn))
        //            cmd.CommandType = CommandType.StoredProcedure;
        //        if (parameters != null && parameters.Length > 0)
        //        {

        //       cm.Parameters.AddRange(parameters);
        //        }

        //    }


        //}
        private DataTable executedatawithparameter(string procedureName, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    DataTable dataTable = new DataTable();

                    connection.Open();

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }

                    return dataTable;
                }
            }
        }

        public DataTable contactus(string procedureName)
        {
            SqlParameter[] parameters = new SqlParameter[0];
            return executedatawithparameter(procedureName, parameters);
        }
    }
}