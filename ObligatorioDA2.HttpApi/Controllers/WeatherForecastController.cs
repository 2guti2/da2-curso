using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ObligatorioDA2.Application.WeatherForecasts;
using ObligatorioDA2.Application.WeatherForecasts.Dtos;

namespace ObligatorioDA2.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IForecastService _forecastService;

        public WeatherForecastController(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecastOutputDto> ReadAll()
        {
            return _forecastService.ReadAll();
        }
        
        [HttpGet("{id:int}")]
        public IActionResult Read(int id)
        {
            WeatherForecastOutputDto forecast = _forecastService.Read(id);
            if (forecast == null)
            {
                return NotFound();
            }
            return Ok(forecast);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] WeatherForecastInputDto forecast)
        {
            WeatherForecastOutputDto createdForecast = _forecastService.Create(forecast);
            return Ok(createdForecast);
        }
        
        [HttpPut]
        public IActionResult Update([FromBody] WeatherForecastInputDto forecast)
        {
            WeatherForecastOutputDto updatedForecast = _forecastService.Update(forecast);
            return Ok(updatedForecast);
        }
        
        [HttpDelete]
        public IActionResult Delete(int forecastId)
        {
            _forecastService.Delete(forecastId);
            return Ok();
        }
    }
}