using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace _2SecondLean.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public User()
        {
            SessionHandler sh = new SessionHandler();

            Email = sh.GetEmail();
            Name = sh.GetName();
            Role = sh.GetRole();
        }

        public static bool UserAuthenticated()
        {
            bool authenticated = false;

            User user = new User();
            if (user.Name != null && user.Name != "")
            {
                authenticated = true;
            }

            return authenticated;
        }

        public static bool ValidateUser(string email, string password)
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            command.CommandText = "Select * FROM Quality.dbo.two_second_lean_users WHERE email = @email AND password = @password";
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                HttpContext.Current.Session["email"] = reader["email"].ToString();
                HttpContext.Current.Session["name"] = reader["name"].ToString();
                HttpContext.Current.Session["role"] = reader["role"].ToString();
                connection.Close();

                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }
    }
}