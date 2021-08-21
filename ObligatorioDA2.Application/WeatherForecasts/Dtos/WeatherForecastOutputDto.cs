using System;

namespace ObligatorioDA2.Application.WeatherForecasts.Dtos
{
    public class WeatherForecastOutputDto
    {
        public int Id { get; set; }
        
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }
        
        public int TemperatureF { get; set; }

        public string Summary { get; set; }
        
        public int UserId { get; set; }
    }
}