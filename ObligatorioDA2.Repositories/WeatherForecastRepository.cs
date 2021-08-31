using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ObligatorioDA2.Domain;
using ObligatorioDA2.EntityFrameworkCore;

namespace ObligatorioDA2.Repositories
{
    public class WeatherForecastRepository : BaseRepository<WeatherForecast>
    {
        public WeatherForecastRepository(Context context)
        {
            _context = context;
        }

        public override WeatherForecast Get(int id)
        {
            return _context.WeatherForecasts.FirstOrDefault(w => w.Id == id);
        }

        public override IEnumerable<WeatherForecast> GetAll()
        {
            return _context.Set<WeatherForecast>().ToList();
        }
    }
}
