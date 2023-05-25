using System.Collections.Generic;
using CrmProject.Models;
//using CrmProject.Database;
using CrmProject.Repositories;

namespace CrmProject.Repositories
{
    public interface IRegisterRepository
    {
        void RegisterUser(RegisterModel registerModel);
        bool IsEmailRegistered(string email);
    }
}
