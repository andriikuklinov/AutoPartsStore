using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.API.Data.Entities;
using Products.API.Data.Initialization;

namespace Products.API.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(product => { 
                product.HasCheckConstraint("CK_Product_Name_Length", "LEN([Name]) >= 3 AND LEN([Name]) < 250");
                product.HasCheckConstraint("CK_Product_Price", "[Price] >= 0");
            });
            builder.Property(product => product.Description).HasMaxLength(1000);

            builder.HasData(ProductInitializer.GetProducts());
        }
    }
}
