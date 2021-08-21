using System.Collections.Generic;
using System.Linq;
using ObligatorioDA2.Application.WeatherForecasts.Dtos;
using ObligatorioDA2.Domain;
using ObligatorioDA2.EntityFrameworkCore;

namespace ObligatorioDA2.Application.WeatherForecasts
{
    public class ForecastService
    {
        private readonly Context _context;

        public ForecastService(Context context)
        {
            _context = context;
        }

        public IEnumerable<WeatherForecastOutputDto> GetAll()
        {
            var forecasts = new List<WeatherForecast>();

            if (!_context.WeatherForecasts.Any())
            {
                forecasts.AddRange(ForecastFactory.NewWeek());
                _context.WeatherForecasts.AddRange(forecasts);
                _context.SaveChanges();
            }
            else
            {
                forecasts.AddRange(_context.WeatherForecasts);
            }

            return forecasts.Select(Mapper.ToDto);
        }
    }
}