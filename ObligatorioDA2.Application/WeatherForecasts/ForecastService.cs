using System;
using System.Collections.Generic;
using System.Linq;
using ObligatorioDA2.Application.WeatherForecasts.Dtos;
using ObligatorioDA2.Domain;
using ObligatorioDA2.EntityFrameworkCore;

namespace ObligatorioDA2.Application.WeatherForecasts
{
    public class ForecastService : IForecastService
    {
        private readonly Context _context;

        public ForecastService(Context context)
        {
            _context = context;
        }

        public IEnumerable<WeatherForecastOutputDto> ReadAll()
        {
            var forecasts = new List<WeatherForecast>();

            if (_context.WeatherForecasts.Any())
            {
                forecasts.AddRange(_context.WeatherForecasts);
            }

            return forecasts.Select(Mapper.ToDto);
        }
        
        public WeatherForecastOutputDto Read(int id)
        {
            return Mapper.ToDto(_context.WeatherForecasts.FirstOrDefault(w => w.Id == id));
        }

        public WeatherForecastOutputDto Create(WeatherForecastInputDto input)
        {
            WeatherForecast forecast = Mapper.ToModel(input);
            _context.Add(forecast);
            _context.SaveChanges();
            return Mapper.ToDto(forecast);
        }

        public WeatherForecastOutputDto Update(WeatherForecastInputDto input)
        {
            WeatherForecast forecast = Mapper.ToModel(input);
            _context.Update(forecast);
            _context.SaveChanges();
            return Mapper.ToDto(forecast);
        }
        
        public void Delete(int id)
        {
            WeatherForecast forecast = _context.WeatherForecasts.FirstOrDefault(w => w.Id == id);
            _context.Remove(forecast ?? throw new InvalidOperationException());
            _context.SaveChanges();
        }
    }
}