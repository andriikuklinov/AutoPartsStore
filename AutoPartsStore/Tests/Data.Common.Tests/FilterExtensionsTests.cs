using Data.Common.Extensions;
using Data.Common.Tests.Models;
using System.Diagnostics;

namespace Data.Common.Tests
{
    [TestFixture]
    public class FilterExtensionsTests
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
                new Product{ Id = 6, Name = "Tire ", Price = 78.89M },
            };
        }

        [Test]
        public void Filter_WhenCallWithFilterByName_ReturnsFilteredCollectionWithThreeElements()
        {
            //Arrange
            var filter = "{\"data\":[{\"PropertyName\":\"Name\",\"Value\":\"Acc\"}]}";
            //Act
            var result = _products.AsQueryable<Product>().Filter<Product>(filter).ToList<Product>();
            //Assert
            Assert.That(result.Count(), Is.EqualTo(3));
        }
        [Test]
        public void Filter_WhenCallWithFilterByPrice_ReturnsCollectionWithOneElement()
        {
            //Arrange
            var filter = "{\"data\":[{\"PropertyName\":\"Price\",\"Value\":\"211,25\"}]}";
            //Act
            var result = _products.AsQueryable<Product>().Filter<Product>(filter).ToList<Product>();
            //Assert
            Assert.That(result.Count(), Is.EqualTo(1));
        }
        [Test]
        public void Filter_WhenCallWithNonExistingValue_ReturnsEmptyCollection()
        {
            //Arrange
            var filter = "{\"data\":[{\"PropertyName\":\"Name\",\"Value\":\"FFFGSX\"}]}";
            //Act
            var result = _products.AsQueryable<Product>().Filter<Product>(filter).ToList<Product>();
            //Assert
            Assert.That(result.Count(), Is.EqualTo(0));
        }
        [Test]
        [TestCase("{[]!}")]
        [TestCase("{}")]
        [TestCase("")]
        [TestCase("[]")]
        public void Filter_WhenCallWithInvalidFilter_ThrowAnArgumentException(string filter)
        {
            Assert.That(() => _products.AsQueryable<Product>().Filter<Product>(filter).ToList<Product>(), Throws.ArgumentException);
        }
    }
}