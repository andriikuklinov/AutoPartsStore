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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<ProductCharacteristic>(new ProductCharacteristicConfiguration());

            modelBuilder.Entity<Product>().HasData(ProductInitializer.GetProducts());
            modelBuilder.Entity<Characteristic>().HasData(CharacteristicInitializer.GetCharacteristics());
            modelBuilder.Entity<ProductCharacteristic>().HasData(ProductCharacteristicsInitializer.GetProductCharacteristics());
        }
    }
}
