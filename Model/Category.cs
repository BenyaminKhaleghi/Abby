using System.ComponentModel.DataAnnotations;

namespace Abby.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Display Order")]
        public string Name { get; set; }
        [Range(1, 100, ErrorMessage ="The Range 1-100")]
        public int DisplayOrder { get; set; }
    }
}