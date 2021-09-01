using System.Linq;
using Microsoft.EntityFrameworkCore;
using ObligatorioDA2.Domain;

namespace ObligatorioDA2.EntityFrameworkCore.Repositories
{
    public class WeatherForecastRepository : BaseRepository<WeatherForecast>
    {
        public WeatherForecastRepository(Context context)
        { 
            Context = context;
        }

        public override WeatherForecast Read(int id)
        {
            return Context.WeatherForecasts.Include(w => w.User).FirstOrDefault(w => w.Id == id);
        }
    }
}