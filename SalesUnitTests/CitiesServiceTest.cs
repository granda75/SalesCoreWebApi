using System.IO;
using NUnit.Framework;
using SalesDal;

namespace SalesUnitTests
{
    public class CitiesServiceTest
    {
        private ICitiesService _citiesService;

        [SetUp]
        public void Setup()
        {
            _citiesService = new CitiesService();

        }

        [Test]
        public void GetCitiesSuccess()
        {
            var cities = _citiesService.GetCities();
            Assert.AreNotEqual(cities, null);
            Assert.Greater(cities.Count, 0);
        }

        [Test]
        public void GetCitiesThrowsExceptionIfFileNotExist()
        {
            if (File.Exists("IsraelCities.csv"))
            {
                File.Delete("IsraelCities.csv");
            }
            var ex = Assert.Throws<FileNotFoundException>(() => _citiesService.GetCities());
            ex?.Message.Equals("IsraelCities.csv does not exist");
        }
    }
}