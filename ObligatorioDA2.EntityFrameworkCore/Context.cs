using Microsoft.EntityFrameworkCore;

namespace ObligatorioDA2.EntityFrameworkCore
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public virtual DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}