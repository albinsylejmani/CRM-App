using System.Collections.Generic;
using System.Linq;
using CrmProject.Database;
using CrmProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CrmProject.Repositories;
using System.Data.SqlClient;
using CrmProject.Database;

namespace CrmProject.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly YourDbContext _dbContext;
        private readonly UserManager<UserModel> _userManager;

        public UserRepository(YourDbContext dbContext, UserManager<UserModel> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public void AddUser(UserModel user)
        {
            _dbContext.CustomUsers.Add(user);
            _dbContext.SaveChanges();
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _dbContext.CustomUsers.ToList();
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

        public IEnumerable<UserModel> GetUsersByRole(string role)
        {
            return _userManager.GetUsersInRoleAsync(role).Result;
        }

        public IEnumerable<UserModel> GetActiveUsers()
        {
            return _dbContext.CustomUsers.Where(u => u.IsActive).ToList();
        }
    }
}
