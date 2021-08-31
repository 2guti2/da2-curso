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
        public ActionResult<IEnumerable<WeatherForecastOutputDto>> ReadAll()
        {
            return Ok(_forecastService.ReadAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<WeatherForecastOutputDto> Read(int id)
        {
            WeatherForecastOutputDto forecast = _forecastService.Read(id);
            if (forecast == null)
            {
                return NotFound();
            }
            return Ok(forecast);
        }

        [HttpPost]
        public ActionResult<WeatherForecastOutputDto> Create([FromBody] WeatherForecastInputDto forecast)
        {
            WeatherForecastOutputDto createdForecast = _forecastService.Create(forecast);
            return Ok(createdForecast);
        }

        [HttpPut]
        public ActionResult<WeatherForecastOutputDto> Update([FromBody] WeatherForecastInputDto forecast)
        {
            WeatherForecastOutputDto updatedForecast = _forecastService.Update(forecast);
            return Ok(updatedForecast);
        }

        [HttpDelete]
        public ActionResult Delete(int forecastId)
        {
            _forecastService.Delete(forecastId);
            return Ok();
        }
    }
}
