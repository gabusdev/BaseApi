using BaseApi.Common.Utils.Request;
using BaseApi.Core.Entities;
using System.Collections.Generic;

namespace BaseApi.Services
{
    public interface IWeatherForecastService
    {
        string Greeting();
        IEnumerable<WeatherForecast> GetForecast(PaginationParams pagParams);
        IEnumerable<WeatherForecast> GetForecast();
    }
}
