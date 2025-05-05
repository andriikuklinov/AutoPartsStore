using System.ComponentModel.DataAnnotations;

namespace Category.API.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
