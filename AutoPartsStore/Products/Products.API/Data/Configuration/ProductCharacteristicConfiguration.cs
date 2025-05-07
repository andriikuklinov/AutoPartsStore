using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.API.Data.Entities;
using System.Reflection.Emit;

namespace Products.API.Data.Configuration
{
    public class ProductCharacteristicConfiguration : IEntityTypeConfiguration<ProductCharacteristic>
    {
        public void Configure(EntityTypeBuilder<ProductCharacteristic> builder)
        {
            builder.HasKey(pc => new { pc.ProductId, pc.CharacteristicId });
            builder.HasOne(pc => pc.Product)
                .WithMany(product => product.ProductCharacteristics)
                .HasForeignKey(pc => pc.ProductId);
            builder.HasOne(pc => pc.Characteristic)
                .WithMany(characteristic => characteristic.ProductCharacteristics)
                .HasForeignKey(pc => pc.CharacteristicId);
        }
    }
}
