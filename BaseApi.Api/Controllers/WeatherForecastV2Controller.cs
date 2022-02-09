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
    [ApiVersion("2.0")] // Version 2
    [ApiController]
    [Route("forecast")]
    public class WeatherForecastV2Controller : ControllerBase
    {
        private readonly ILogger<WeatherForecastV2Controller> _logger;
        private readonly IWeatherForecastService _service;

        public WeatherForecastV2Controller(ILogger<WeatherForecastV2Controller> logger,
            IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }
        
        [HttpGet]
        [MapToApiVersion("2.0")]
        public ActionResult<WeatherForecast> Get([FromQuery] PaginationParams pagParams)
        {
            return Ok(_service.GetForecast(pagParams));
        }

        [HttpGet("/greet")]
        [MapToApiVersion("2.0")]
        public ActionResult<string> Greet()
        {
            return Ok(_service.Greeting() + "from V2");
        }
    }

    
}
