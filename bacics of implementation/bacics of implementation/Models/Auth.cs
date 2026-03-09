using System.ComponentModel.DataAnnotations;

namespace bacics_of_implementation.Models
{
    public class Auth
    {
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string Confirmpassword { get; set; }
    }
}
