using System.Collections.Generic;

namespace ObligatorioDA2.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public virtual ICollection<WeatherForecast> Forecasts { get; set; }
    }
}
