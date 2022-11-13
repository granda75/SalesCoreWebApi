using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SalesDal;

namespace SalesCoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesService _citiesService;

        public CitiesController(ICitiesService citiesService)
        {
            _citiesService = citiesService;
        }

        [HttpGet]
        public IEnumerable<string> GetCities()
        {
            var cities = _citiesService.GetCities();
            var strCities = cities.Select(l => l.CityName);
            return strCities;
        }
    }
}
