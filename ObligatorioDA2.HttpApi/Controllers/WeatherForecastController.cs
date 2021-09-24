using System.Collections.Generic;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ObligatorioDA2.Application.Contracts.WeatherForecasts;
using ObligatorioDA2.Application.Contracts.WeatherForecasts.Dtos;
using ObligatorioDA2.HttpApi.Filters;

namespace ObligatorioDA2.HttpApi.Controllers
{
    [ApiController]
    [ExceptionFilter]
    [AuthenticationFilter]
    [Route("[controller]")]
    public class WeatherForecastController : CustomControllerBase
    {
        private readonly IForecastService _forecastService;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            IForecastService forecastService,
            ILogger<WeatherForecastController> logger
        )
        {
            _forecastService = forecastService;
            _logger = logger;
        }

        [HttpGet]
        [AuthorizeAction("ReadForecasts")]
        public ActionResult<IEnumerable<WeatherForecastOutputDto>> ReadAll([FromQuery(Name = "summary")] string summary)
        {
            _logger.LogInformation($"Username is: {Username}");
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
        [AuthorizeAction("CreateForecasts")]
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

        [HttpDelete]
        public ActionResult Delete(int forecastId)
        {
            _forecastService.Delete(forecastId);
            return Ok();
        }
    }
}
