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
    }
}
