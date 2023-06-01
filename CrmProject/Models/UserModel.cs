using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace CrmProject.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; } // Add the Role property

        public bool IsActive { get; set; }
        public string Password { get; set; }
    }
}
