using BaseApi.Common.Utils.Request;
using BaseApi.Core.Entities;
using BaseApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Api.Controllers
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("forecast")]
    public class WeatherForecastV2Controller : ControllerBase
    {
        private readonly IWeatherForecastService _service;

        public WeatherForecastV2Controller(IWeatherForecastService service)
        {
            _service = service;
        }
        
        [Authorize(Policy = "AdminRights")]
        [HttpGet]
        public ActionResult<WeatherForecast> Get([FromQuery] PaginationParams pagParams)
        {
            return Ok(_service.GetForecast(pagParams));
        }

        [Authorize]
        [HttpGet("/greet")]
        public ActionResult<string> Greet()
        {
            return Ok(_service.Greeting() + " from V2");
        }
    }


}
