using ObligatorioDA2.Application.WeatherForecasts.Dtos;
using ObligatorioDA2.Domain;

namespace ObligatorioDA2.Application
{
    public static class Mapper
    {
        public static WeatherForecastOutputDto ToDto(WeatherForecast forecast)
        {
            return new WeatherForecastOutputDto
            {
                Id = forecast.Id,
                Date = forecast.Date,
                Summary = forecast.Summary,
                TemperatureC = forecast.TemperatureC,
                TemperatureF = forecast.TemperatureF,
                UserId = forecast.UserId
            };
        }
        public static WeatherForecast ToModel(WeatherForecastInputDto forecast)
        {
            return new WeatherForecast
            {
                Id = forecast.Id,
                Date = forecast.Date,
                Summary = forecast.Summary,
                TemperatureC = forecast.TemperatureC,
                UserId = forecast.UserId
            };
        }
    }
}