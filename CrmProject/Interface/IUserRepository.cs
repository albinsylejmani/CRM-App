using System.Collections.Generic;
using CrmProject.Models;
//using CrmProject.Database;

namespace CrmProject.Repositories
{
    public interface IUserRepository
    {
        void AddUser(UserModel user);
        UserModel GetUserById(int id);
        UserModel GetUserByEmail(string email);
        List<UserModel> GetAllUsers();
        void UpdateUser(UserModel user);
        void DeleteUser(UserModel user);
        IEnumerable<UserModel> GetUsersByRole(string role);
        IEnumerable<UserModel> GetUsersByStatus(bool isActive);
    }
}
