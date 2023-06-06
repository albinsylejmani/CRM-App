using System;
using System.Threading;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using CrmProject.Models;

namespace CrmProject.Repositories
{
    public class YourUserStoreImplementation : IUserStore<UserModel>, IDisposable
    {
        public Task<string> GetUserIdAsync(UserModel user, CancellationToken cancellationToken)
        {
            // Your logic for getting the user ID
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(UserModel user, CancellationToken cancellationToken)
        {
            // Your logic for getting the user name
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(UserModel user, string userName, CancellationToken cancellationToken)
        {
            // Your logic for setting the user name
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(UserModel user, CancellationToken cancellationToken)
        {
            // Your logic for getting the normalized user name
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(UserModel user, string normalizedName, CancellationToken cancellationToken)
        {
            // Your logic for setting the normalized user name
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(UserModel user, CancellationToken cancellationToken)
        {
            // Your logic for creating a new user
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(UserModel user, CancellationToken cancellationToken)
        {
            // Your logic for updating a user
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(UserModel user, CancellationToken cancellationToken)
        {
            // Your logic for deleting a user
            throw new NotImplementedException();
        }

        public Task<UserModel> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            // Your logic for finding a user by ID
            throw new NotImplementedException();
        }

        public Task<UserModel> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            // Your logic for finding a user by name
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // Your logic for disposing resources
            throw new NotImplementedException();
        }
    }
}