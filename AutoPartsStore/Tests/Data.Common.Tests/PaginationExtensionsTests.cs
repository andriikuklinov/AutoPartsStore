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
    public class PaginationExtensionsTests
    {
        private IEnumerable<Product> _products;
        [SetUp]
        public void SetUp()
        {
            _products = new List<Product>
            {
                new Product{ Id = 1, Name = "Accumulator", Price = 123.5M },
                new Product{ Id = 2, Name = "Accumulator 2", Price = 127.2M },
                new Product{ Id = 3, Name = "Accumulator_M2BS", Price = 103.15M },
                new Product{ Id = 4, Name = "Tire 1", Price = 211.25M },
                new Product{ Id = 5, Name = "Tire 1", Price = 123 },
                new Product{ Id = 6, Name = "Tire ", Price = 78.89M }
            };
        }

        [Test]
        [TestCase(0, 2, 2)]
        [TestCase(1, 2, 2)]
        public void Paginate_WhenCallWithPageAndCount_ReturnCollectionWithSpecificCount(int page, int count, int resultCount)
        {
            var result = _products.AsQueryable<Product>().Paginate(page, count).ToList<Product>();
            Assert.That(result.Count, Is.EqualTo(resultCount));
        }

        [Test]
        [TestCase(0, 2, 1)]
        public void Paginate_WhenCallWithPageAndCount_ReturnItemsWithSpecificId(int page, int count, int productId)
        {
            var result = _products.AsQueryable<Product>().Paginate(page, count).ToList<Product>().FirstOrDefault();
            Assert.That(result.Id, Is.EqualTo(productId));
        }
    }
}
