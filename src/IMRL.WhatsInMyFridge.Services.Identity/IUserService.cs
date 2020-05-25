using IMRL.WhatsInMyFridge.Core.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace IMRL.WhatsInMyFridge.Services.Identity
{
    public interface IUserService
    {
        Task<User> SignInService(string Username, string Password);

        Task<User> RegisterUserService(string Username, string Password);
    }
    public class UserService : IUserService
    {
        public static string connectionString = "Data Source=DESKTOP-NK0HCAB;Initial Catalog=FridgeContents;Integrated Security=True";
        SqlConnection con = new SqlConnection(connectionString);
        string q;
        public Task<User> RegisterUserService(string Username, string Password)
        {
            con.Open();
            q = "insert into Users(Id,Username,PasswordHash,Role)values('" + Guid.NewGuid() + "','" + Username + "','" + Password + "','" + "User" + "')";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            var result = new User(Username, "User");
            con.Close();
            return Task.FromResult(result);
        }

        public Task<User> SignInService(string Username, string Password)
        {
            User user = new User("", "");
            con.Open();

            q = "select * from Users where (Username='" + Username + "' and PasswordHash='" + Password + "')";
            using (SqlCommand command = new SqlCommand(q, con))
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    user.Username = Username;
                    user.Role= reader[3].ToString();
                    reader.Close();
                }
                else {
                    reader.Close();
                }


            }
            con.Close();
            return Task.FromResult(user);
        }
    }

}

