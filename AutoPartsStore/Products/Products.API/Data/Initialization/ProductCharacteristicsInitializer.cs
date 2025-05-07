using Products.API.Data.Entities;

namespace Products.API.Data.Initialization
{
    public class ProductCharacteristicsInitializer
    {
        public static IEnumerable<ProductCharacteristic> GetProductCharacteristics()
        {
            return new List<ProductCharacteristic>()
            {
                new ProductCharacteristic(){ ProductId =1 ,CharacteristicId=1 , Value="12" },
                new ProductCharacteristic(){ ProductId =1 ,CharacteristicId=2 , Value="100" },
                new ProductCharacteristic(){ ProductId =1 ,CharacteristicId=5 , Value="AGM" },
                new ProductCharacteristic(){ ProductId =2 ,CharacteristicId=1 , Value="24" },
                new ProductCharacteristic(){ ProductId =2 ,CharacteristicId=2 , Value="200" },
                new ProductCharacteristic(){ ProductId =2 ,CharacteristicId=5 , Value="AGM" },
                new ProductCharacteristic(){ ProductId =3 ,CharacteristicId=3 , Value="20" },
                new ProductCharacteristic(){ ProductId =3 ,CharacteristicId=4 , Value="14" },
                new ProductCharacteristic(){ ProductId =4 ,CharacteristicId=3 , Value="20" },
                new ProductCharacteristic(){ ProductId =4 ,CharacteristicId=4 , Value="18" }
            };
        }
    }
}
