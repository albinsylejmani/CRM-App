using System.ComponentModel.DataAnnotations;

namespace YourProject.Models
{
    public class UserRegistrationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        // Add any additional fields needed for user registration
    }
}
