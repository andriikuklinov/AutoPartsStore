using Data.Common.Extensions;
using Data.Common.Tests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common.Tests
{
    [TestFixture]
    public class OrderExtensionsTests
    {
        private IEnumerable<Product> _products;

        [SetUp]
        public void SetUp()
        {
            _products = new List<Product>
            {
                new Product{ Id = 3, Name = "Accumulator_M2BS", Price = 103.15M },
                new Product{ Id = 2, Name = "Tire 1", Price = 211.25M },
                new Product{ Id = 3, Name = "Tire 1", Price = 123 },
                new Product{ Id = 4, Name = "Tire ", Price = 78.89M },
                new Product{ Id = 2, Name = "Accumulator C2", Price = 127.2M },
                new Product{ Id = 1, Name = "Accumulator", Price = 123.5M }
            };
        }

        [Test]
        [TestCase("asc", 1)]
        [TestCase("desc", 2)]
        public void OrderBy_WhenFilterByNameWithDirection_FirstElementIdIsEqualResultId(string direction, int resultId)
        {
            var orderCondition = "{\"data\":[{\"PropertyName\":\"Name\",\"Direction\":\"asc\"}]}".Replace("asc", direction);
            var result = _products.AsQueryable<Product>().OrderBy(orderCondition).ToList<Product>();

            Assert.That(result.First().Id, Is.EqualTo(resultId));
        }

        [Test]
        [TestCase("{[]!}")]
        [TestCase("{}")]
        [TestCase("")]
        [TestCase("[]")]
        public void Order_WhenCallWithInvalidOrder_ThrowAnArgumentException(string order)
        {
            Assert.That(() => _products.AsQueryable<Product>().OrderBy(order).ToList<Product>(), Throws.ArgumentException);
        }
    }
}
