using YourProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace YourProject.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly YourDbContext _dbContext;

        public UserRepository(YourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public User GetUserByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
