using BaseApi.Common.Utils.Request;
using BaseApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace BaseApi.Services.Impl
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public IEnumerable<WeatherForecast> GetForecast(PaginationParams pagParams)
        {
            var rng = new Random();
            var forecasts = Enumerable.Range(1, 50).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return forecasts.ToPagedList(pagParams.PageNumber, pagParams.PageSize);
        }

        public IEnumerable<WeatherForecast> GetForecast()
        {
            var rng = new Random();
            return Enumerable.Range(1, 50).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public string Greeting()
        {
            return "Hi there from this Service";
        }
    }
}
