using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ObligatorioDA2.Application.Interface;
using ObligatorioDA2.Application.WeatherForecasts.Dtos;
using ObligatorioDA2.Domain;

namespace ObligatorioDA2.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IService<WeatherForecast> _forecastService;

        public WeatherForecastController(IService<WeatherForecast> service) : base()
        {
            this._forecastService = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecastOutputDto> Get()
        {
            return _forecastService.GetAll().Select(Mapper.ToDto);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var forecast = _forecastService.Get(id);
            if (forecast == null)
            {
                return NotFound();
            }
            return Ok(forecast);
        }
        [HttpPost]
        public IActionResult Post([FromBody] WeatherForecastInputDto forecast)
        {
            try
            {
                _forecastService.Create(Mapper.ToModel(forecast));
            } catch(ArgumentException e) {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] WeatherForecastInputDto forecast,int id)
        {
            try { 
            _forecastService.Update(id, Mapper.ToModel(forecast));
        } catch(ArgumentException e) {
                return BadRequest(e.Message);
        }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int forecastId)
        {
            try
            {
                _forecastService.Delete(forecastId);
            } catch(ArgumentException e) {
                return NotFound(e.Message);
            }
            return Ok();
        }
    }
}

