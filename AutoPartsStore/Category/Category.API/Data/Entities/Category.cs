using System.ComponentModel.DataAnnotations;

namespace Category.API.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public required string Name { get; set; }
    }
}
