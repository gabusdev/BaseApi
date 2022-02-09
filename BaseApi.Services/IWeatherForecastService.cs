using BaseApi.Common.Utils.Request;
using BaseApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApi.Services
{
    public interface IWeatherForecastService
    {
        string Greeting();
        IEnumerable<WeatherForecast> GetForecast(PaginationParams pagParams);
        IEnumerable<WeatherForecast> GetForecast();
    }
}
