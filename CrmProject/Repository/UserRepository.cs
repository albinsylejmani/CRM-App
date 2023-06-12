using System.Collections.Generic;
using System.Linq;
using CrmProject.Database;
using CrmProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CrmProject.Repositories;
using System.Data.SqlClient;
using CrmProject.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CrmProject.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly YourDbContext _dbContext;
        private readonly List<UserModel> _users;
        private readonly string _connectionString;

        public UserRepository(YourDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AddUser(UserModel user)
        {
            _dbContext.CustomUsers.Add(user);
            _dbContext.SaveChanges();
        }
        

        public async Task<List<UserModel>> GetUsers()
        {
        string query = "SELECT * FROM CrmDB.dbo.Users WHERE Role IS NOT NULL "; // Modify the query
         return await _dbContext.CustomUsers.FromSqlRaw(query).ToListAsync();
        }

        public async Task<UserModel> GetUserById(string id)
        {
            if (int.TryParse(id, out int userId))
        {
            string query = "SELECT * FROM CrmDB.dbo.Users WHERE Role IS NOT NULL AND Id = @UserId";
            return await _dbContext.CustomUsers.FromSqlRaw(query, new Microsoft.Data.SqlClient.SqlParameter("@UserId", userId)).FirstOrDefaultAsync();
        }

            return null;
        }


        public UserModel GetUserByEmail(string email)
        {
            return _dbContext.CustomUsers.FirstOrDefault(u => u.Email == email);
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _dbContext.CustomUsers.ToList();
        }

        public void UpdateUser(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

        string query = "UPDATE Users SET " +
                       "Email = @Email, " +
                       "Password = @Password, " +
                       "FirstName = @FirstName, " +
                       "LastName = @LastName, " +
                       "Role = @Role, " +
                       "IsActive = @IsActive " +
                       "WHERE Id = @Id";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@IsActive", user.IsActive);
                command.Parameters.AddWithValue("@Id", user.Id);

                command.ExecuteNonQuery();
            }
        }
    }


        public void DeleteUser(UserModel user)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Open();

        string query = "DELETE FROM Users WHERE Id = @Id";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Id", user.Id);

            command.ExecuteNonQuery();
        }
    }
}

        /*public IEnumerable<UserModel> GetUsersByRole(string role)
        {
            return _dbContext.GetUsersInRoleAsync(role).Result;
        }*/

        public IEnumerable<UserModel> GetActiveUsers()
        {
            return _dbContext.CustomUsers.Where(u => u.IsActive).ToList();
        }
    }
}
