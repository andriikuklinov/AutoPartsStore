using Products.API.Data.Entities;

namespace Products.API.Data.Initialization
{
    public class ProductInitializer
    {
        public static IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product(){ Id=1, Name="Bosh 12v", Description="Accumulator" },
                new Product(){ Id=2, Name="Varta 12v", Description="Accumulator" },
                new Product(){ Id=3, Name="Tire R14", Description="tire"},
                new Product(){ Id=4, Name="Tire R13", Description="tire 13"}
            };
        }
    }
}
