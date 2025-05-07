using Products.API.Data.Entities;

namespace Products.API.Data.Initialization
{
    public class CharacteristicInitializer
    {
        public static IEnumerable<Characteristic> GetCharacteristics()
        {
            return new List<Characteristic>()
            {
                new Characteristic(){ Id=1, Name="Voltage", Unit="V"},
                new Characteristic(){ Id=2, Name="Capacity", Unit="Ah"},
                new Characteristic(){ Id=3, Name="Width", Unit="cm"},
                new Characteristic(){ Id=4, Name="Radius", Unit="cm"},
                new Characteristic(){ Id=5, Name="Type"},
            };
        }
    }
}
