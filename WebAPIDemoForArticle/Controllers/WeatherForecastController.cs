using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPIDemoForArticle.DataAccess;

namespace WebAPIDemoForArticle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly MongoDBAccessor _accessor;

        public WeatherForecastController(MongoDBAccessor accessor)
        {
            _accessor = accessor;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _accessor.GetForecasts();
        }
    }
}