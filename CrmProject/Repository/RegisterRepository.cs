using System.Collections.Generic;
using System.Linq;
using CrmProject.Models;
using CrmProject.Database;
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
            var user = new UserModel
            {
                Email = registerModel.Email,
                Password = registerModel.Password,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Role = registerModel.Role, // Assign the role from the registerModel
                IsActive = true // Set the initial status
            };

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Users (Email, Password, FirstName, LastName, Role, IsActive) " +
                               "VALUES (@Email, @Password, @FirstName, @LastName, @Role, @IsActive)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Role", user.Role);
                    command.Parameters.AddWithValue("@IsActive", user.IsActive);

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
