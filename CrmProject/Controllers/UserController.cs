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
    }
}
