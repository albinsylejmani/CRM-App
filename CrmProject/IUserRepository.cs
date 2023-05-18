using YourProject.Models;
using System.Collections.Generic;

namespace YourProject.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user); // New method added

        User GetUserById(int id);
        User GetUserByEmail(string email);
        List<User> GetAllUsers();
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}