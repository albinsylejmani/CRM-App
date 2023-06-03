using System.ComponentModel.DataAnnotations;
using CrmProject.Models;

namespace CrmProject.Models
{
    public class RegisterModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    public string Role { get; set; }
}
}
