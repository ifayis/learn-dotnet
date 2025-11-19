using System.ComponentModel.DataAnnotations;

namespace review_week2.Model
{
    public class Students
    {
        public int Id { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Name should be atleast 2 characters.")]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
