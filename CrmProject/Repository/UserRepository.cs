using System.Collections.Generic;
using System.Linq;
using CrmProject.Models;
using CrmProject.Database;

namespace CrmProject.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly YourDbContext _dbContext;

        public UserRepository(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserModel GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public UserModel GetUserByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public List<UserModel> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void AddUser(UserModel user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(UserModel user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(UserModel user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public IEnumerable<UserModel> GetUsersByRole(string role)
        {
            return _dbContext.Users.Where(u => u.Role == role).ToList();
        }

        public IEnumerable<UserModel> GetUsersByStatus(bool isActive)
        {
            return _dbContext.Users.Where(u => u.IsActive == isActive).ToList();
        }
    }
}
