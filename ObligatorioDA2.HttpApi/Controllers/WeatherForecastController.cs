using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ObligatorioDA2.Application.WeatherForecasts;
using ObligatorioDA2.Application.WeatherForecasts.Dtos;
using ObligatorioDA2.EntityFrameworkCore;

namespace ObligatorioDA2.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ForecastService _forecastService;

        public WeatherForecastController(Context context)
        {
            _forecastService = new ForecastService(context);
        }

        [HttpGet]
        public IEnumerable<WeatherForecastOutputDto> Get()
        {
            return _forecastService.GetAll();
        }
    }
}
