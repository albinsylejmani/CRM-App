using System;
using Microsoft.AspNetCore.Mvc;
using CrmProject.Models;
using CrmProject.Repositories;

namespace CrmProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterRepository _registerRepository;

        public RegisterController(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        [HttpPost]
        public IActionResult RegisterUser(RegisterModel registerModel)
        {
            try
            {
                // Perform validation on the registerModel if needed

                // Check if the email is already registered
                if (_registerRepository.IsEmailRegistered(registerModel.Email))
                {
                    return BadRequest("Email already registered");
                }

                // Register the user
                _registerRepository.RegisterUser(registerModel);

                return Ok(new { message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an appropriate response
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
