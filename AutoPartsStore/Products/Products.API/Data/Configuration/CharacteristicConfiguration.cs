using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.API.Data.Entities;
using Products.API.Data.Initialization;

namespace Products.API.Data.Configuration
{
    public class CharacteristicConfiguration : IEntityTypeConfiguration<Characteristic>
    {
        public void Configure(EntityTypeBuilder<Characteristic> builder)
        {
            builder.ToTable(characteristic =>
            {
                characteristic.HasCheckConstraint("CH_Characteristic_NameLength", "LEN([Name]) >= 3 AND LEN([Name] < 250)");
            });
            builder.HasData(CharacteristicInitializer.GetCharacteristics());
        }
    }
}
