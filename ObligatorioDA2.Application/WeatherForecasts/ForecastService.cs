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

            if (_context.WeatherForecasts.Any())
            {
                forecasts.AddRange(_context.WeatherForecasts);
            }
            return forecasts.Select(Mapper.ToDto);
        }
        public WeatherForecastOutputDto Get(int id)
        {

            return Mapper.ToDto(_context.WeatherForecasts.FirstOrDefault(w => w.Id == id));
        }
        
        public void Create(WeatherForecastInputDto forecast){
            _context.Add(Mapper.ToModel(forecast));
            _context.SaveChanges();
        }

        public void Update(WeatherForecastInputDto forecast){
            _context.Update(Mapper.ToModel(forecast));
            _context.SaveChanges();
        }
        public void Delete(int id){
            _context.Remove(_context.WeatherForecasts.FirstOrDefault(w => w.Id == id));
            _context.SaveChanges();
        }
    }
}