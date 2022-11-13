
using CsvHelper.Configuration.Attributes;

namespace SalesDal
{
    public class City
    {
        [Index(0)]
        public string CityName { get; set; }
    }
}
