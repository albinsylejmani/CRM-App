using System.Collections.Generic;
using CrmProject.Models;
//using CrmProject.Database;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;





namespace CrmProject.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly string _connectionString;

        public RegisterRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void RegisterUser(RegisterModel registerModel)
        {
            // Create a new UserModel entity and populate its properties
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Users (Email, Password, FirstName, LastName) VALUES (@Email, @Password, @FirstName, @LastName)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", registerModel.Email);
                    command.Parameters.AddWithValue("@Password", registerModel.Password);
                    command.Parameters.AddWithValue("@FirstName", registerModel.FirstName);
                    command.Parameters.AddWithValue("@LastName", registerModel.LastName);

                    command.ExecuteNonQuery();
                }
            }
        }

        public bool IsEmailRegistered(string email)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

    }
}
