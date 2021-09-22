﻿using System.Collections.Generic;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using ObligatorioDA2.Application.Contracts.WeatherForecasts;
using ObligatorioDA2.Application.Contracts.WeatherForecasts.Dtos;
using ObligatorioDA2.Domain.Exceptions;

namespace ObligatorioDA2.HttpApi.Controllers
{
    [ApiController]
    [CustomAuthorizationFilter]
    [ExceptionFilter]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IForecastService _forecastService;

        public WeatherForecastController(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecastOutputDto>> ReadAll([FromQuery(Name = "summary")] string summary)
        {
            return Ok(summary.IsNullOrEmpty()
                ? _forecastService.ReadAll()
                : _forecastService.ReadAllWithSummary(summary));
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

        [HttpPut("{id:int}")]
        public ActionResult<WeatherForecastOutputDto> Update(int id, [FromBody] WeatherForecastInputDto forecast)
        {
            WeatherForecastOutputDto updatedForecast = _forecastService.Update(id, forecast);
            return Ok(updatedForecast);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            _forecastService.Delete(id);
            return Ok();

        }
    }
}
