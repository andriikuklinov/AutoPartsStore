using Microsoft.EntityFrameworkCore;
using Products.API.Data.Configuration;
using Products.API.Data.Entities;
using Products.API.Data.Initialization;

namespace Products.API.Data
{
    public class ProductContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<ProductCharacteristic> ProductsCharacteristics { get; set; }

        public ProductContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<ProductCharacteristic>(new ProductCharacteristicConfiguration());
            modelBuilder.ApplyConfiguration<Product>(new ProductConfiguration());
            modelBuilder.ApplyConfiguration<Characteristic>(new CharacteristicConfiguration());
        }
    }
}
