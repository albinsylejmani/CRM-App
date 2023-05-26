using CrmProject.Models;

namespace CrmProject.Repositories
{
    public interface ILoginRepository
    {
        bool ValidateCredentials(LoginModel loginModel);
    }
}
