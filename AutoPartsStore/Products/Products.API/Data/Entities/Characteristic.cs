using System.ComponentModel.DataAnnotations;

namespace Products.API.Data.Entities
{
    public class Characteristic
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Unit { get; set; }
        public ICollection<ProductCharacteristic> ProductCharacteristics { get; set; }
    }
}
