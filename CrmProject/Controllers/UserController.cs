using Microsoft.AspNetCore.Mvc;
using CrmProject.Models;
using CrmProject.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CrmProject.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository =  userRepository; // Instantiate UserRepository directly
        }

        [HttpGet]
            public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            var userList = users.ToList();
            return Ok(userList);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, UserModel updatedUser)
        {
            var user = await  _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.Role = updatedUser.Role;
            user.IsActive = updatedUser.IsActive;

            _userRepository.UpdateUser(user);

            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id, UserModel deletedUser)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound(); // Return 404 Not Found if the user does not exist
            }

            user.FirstName = deletedUser.FirstName;
            user.LastName = deletedUser.LastName;
            user.Email = deletedUser.Email;
            user.Role = deletedUser.Role;
            user.IsActive = deletedUser.IsActive;

            _userRepository.DeleteUser(user);

            return NoContent(); // Return 204 No Content to indicate successful deletion
        }
    }
}
