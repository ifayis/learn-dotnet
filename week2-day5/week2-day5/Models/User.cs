using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace week2_day5.Models
{
    public class User
    {
        [Required]
        [StringLength(500, MinimumLength = 0, ErrorMessage = "username cant be empty")]
        public string Username { get; set; }
        
        [StringLength(20, MinimumLength = 5, ErrorMessage = "password must between 5 and 20 characters")]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
