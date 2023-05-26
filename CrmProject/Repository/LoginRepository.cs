using CrmProject.Models;
using CrmProject.Database;
using System.Data.SqlClient;

namespace CrmProject.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly string _connectionString;

        public LoginRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool ValidateCredentials(LoginModel loginModel)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", loginModel.Email);
                    command.Parameters.AddWithValue("@Password", loginModel.Password);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }
    }
}
