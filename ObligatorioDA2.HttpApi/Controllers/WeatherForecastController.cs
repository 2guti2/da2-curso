using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ObligatorioDA2.EntityFrameworkCore;

namespace ObligatorioDA2.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Context _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var forecasts = new List<WeatherForecast>();
            
            if (!_context.WeatherForecasts.Any())
            {
                var rng = new Random();
                forecasts.AddRange(Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }));
                _context.WeatherForecasts.AddRange(forecasts);
                _context.SaveChanges();
            }
            else
            {
                forecasts.AddRange(_context.WeatherForecasts);
            }
            
            return forecasts;
        }
    }
}
