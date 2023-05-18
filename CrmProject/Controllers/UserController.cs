// UserController.cs
using Microsoft.AspNetCore.Mvc;
using YourProject.Models;
using YourProject.Repositories;

namespace YourProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegistrationModel userRegistration)
        {
            // Perform validation on userRegistration data if needed

            // Create a new User object from the registration data
            var user = new User
            {
                Email = userRegistration.Email,
                Password = userRegistration.Password,
                // Set other properties as needed
            };

            // Register the user by calling the AddUser method of the UserRepository
            _userRepository.AddUser(user);

            return Ok("User registered successfully!");
        }
    }
}
