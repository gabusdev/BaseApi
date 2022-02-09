using BaseApi.Core.Entities;
using BaseApi.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BaseApi.Api.Controllers
{
    [ApiVersion("1.0", Deprecated = true)] // Version 1, deprecated
    [ApiController]
    [Route("forecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _service;

        public WeatherForecastController(IWeatherForecastService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<WeatherForecast> Get()
        {
            return Ok(_service.GetForecast());
        }

        [HttpGet("/greet")]
        public ActionResult<string> Greet()
        {
            Log.Information("Greeted from V 1.0");
            return Ok(_service.Greeting() + " from V1");
        }
    }


}
