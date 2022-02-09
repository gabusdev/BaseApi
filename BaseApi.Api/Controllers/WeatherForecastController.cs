using BaseApi.Common.Utils.Request;
using BaseApi.Core.Entities;
using BaseApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.Api.Controllers
{
    //[ApiVersion("1.0", Deprecated = true)] // Version 1, deprecated
    [ApiController]
    [Route("forecast")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IWeatherForecastService service)
        {
            _logger = logger;
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
            return Ok(_service.Greeting() + "from V1");
        }
    }

    
}
