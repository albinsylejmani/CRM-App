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

        public UserModel GetUserById(string id)
        {
            if (int.TryParse(id, out int userId))
        {
            return _dbContext.CustomUsers.FirstOrDefault(u => u.Id == userId);
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
            _dbContext.CustomUsers.Update(user);
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
