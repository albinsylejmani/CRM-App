using System.Collections.Generic;
using CrmProject.Models;
using CrmProject.Repositories;
using System.Threading.Tasks;

namespace CrmProject.Repositories
{
    public interface IUserRepository
    {
        void AddUser(UserModel user);
        Task<UserModel> GetUserById(string id);
        UserModel GetUserByEmail(string email);
        //List<UserModel> GetAllUsers();
        void UpdateUser(UserModel user);
        void DeleteUser(UserModel user);
        //IEnumerable<UserModel> GetUsersByRole(string role);
        //IEnumerable<UserModel> GetUsersByStatus(bool isActive);
        Task<List<UserModel>> GetUsers();
    }
}