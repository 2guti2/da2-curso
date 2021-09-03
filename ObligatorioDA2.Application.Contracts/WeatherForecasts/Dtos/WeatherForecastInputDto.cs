using System;

namespace ObligatorioDA2.Application.Contracts.WeatherForecasts.Dtos
{
    public class WeatherForecastInputDto
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int? UserId { get; set; } = null;
    }
}