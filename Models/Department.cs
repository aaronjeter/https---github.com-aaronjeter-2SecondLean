using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace _2SecondLean.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Area { get; set; }

        public static List<string> GetDepartments()
        {
            List<string> departments = new List<string>();

            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            command.CommandText = "Select * FROM Quality.dbo.two_second_lean_Areas";
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (reader["Area"] != DBNull.Value)
                {
                    departments.Add(reader["Area"].ToString());
                }
            }
            connection.Close();

            return departments;
        }
    }
}