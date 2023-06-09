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

        public UserRepository(YourDbContext dbContext)
        {
            _dbContext = dbContext;
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
    string query = "UPDATE Users SET " +
                   "FirstName = @FirstName, " +
                   "LastName = @LastName, " +
                   "Email = @Email, " +
                   "Role = @Role, " +
                   "IsActive = @IsActive " +
                   "WHERE Id = @Id";

    _dbContext.Database.ExecuteSqlRaw(query,
        new Microsoft.Data.SqlClient.SqlParameter("@FirstName", user.FirstName),
        new Microsoft.Data.SqlClient.SqlParameter("@LastName", user.LastName),
        new Microsoft.Data.SqlClient.SqlParameter("@Email", user.Email),
        new Microsoft.Data.SqlClient.SqlParameter("@Role", user.Role),
        new Microsoft.Data.SqlClient.SqlParameter("@IsActive", user.IsActive),
        new Microsoft.Data.SqlClient.SqlParameter("@Id", user.Id));

    _dbContext.SaveChanges();
}

        public void DeleteUser(UserModel user)
        {
            _dbContext.CustomUsers.Remove(user);
            _dbContext.SaveChanges();
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
