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
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var forecast = _forecastService.Get(id);
            if (forecast == null) {
                return NotFound();
            }
            return Ok(forecast);
        }
        [HttpPost]
        public IActionResult Post([FromBody]WeatherForecastInputDto forecast)
        {
            _forecastService.Create(forecast);
            return Ok();
        }
        [HttpPut]
        public IActionResult Put([FromBody]WeatherForecastInputDto forecast)
        {
            _forecastService.Update(forecast);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Put(int forecastId)
        {
            _forecastService.Delete(forecastId);
            return Ok();
        }
    }
}
/*
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = users.Get(id);
            if (user == null) {
                return NotFound();
            }
            return Ok(UserModel.ToModel(user));
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserModel model)
        {
            try {
                var user = users.Create(UserModel.ToEntity(model));
                return CreatedAtRoute("Get", new { id = user.Id }, UserModel.ToModel(user));
            } catch(ArgumentException e) {
                return BadRequest(e.Message);
            }
        }
*/