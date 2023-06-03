using Microsoft.AspNetCore.Mvc;
using CrmProject.Models;
using CrmProject.Repositories;

namespace CrmProject.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            return Ok(users);
        }
    }
}
