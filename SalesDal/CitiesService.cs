using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace SalesDal
{
    public class CitiesService : ICitiesService
    {
        private const string CitiesFileName = "IsraelCities.csv";
        public List<City> GetCities()
        {
            if (!File.Exists(CitiesFileName)) throw new FileNotFoundException("IsraelCities.csv does not exist");

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using var reader = new StreamReader(CitiesFileName);
            using var csv = new CsvReader(reader, configuration);
            var cities = csv.GetRecords<City>().ToList();
            return cities;
        }
    }
}