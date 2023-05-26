using Microsoft.AspNetCore.Mvc;
using CrmProject.Models;
using CrmProject.Repositories;

namespace CrmProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            if (_loginRepository.ValidateCredentials(loginModel))
            {
                return Ok("Login successful!");
            }
            else
            {
                return Unauthorized("Invalid login credentials");
            }
        }
    }
}
