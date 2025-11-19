using System.ComponentModel.DataAnnotations;

namespace week2_day4.Models
{
    public class Items
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Title is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage ="Title must be between 1 and 100 chartacters.")]
        public string Title { get; set; }


        [StringLength(500, ErrorMessage ="Description cannot exceed more than 500 characters.")]
        public string Description { get; set; }

      
        [Range(0,double.MaxValue, ErrorMessage ="Price must be a positive value")]
        public decimal Price { get; set; }
    }
}
public class CreateItem
{
    [Required]
    [StringLength(100, MinimumLength =1)]
    public string Title { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }
}

public class UpdateItem
{
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Title { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }
}