using ObligatorioDA2.Application.Contracts.Users.Dtos;
using ObligatorioDA2.Application.Contracts.WeatherForecasts.Dtos;
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
                User = forecast.User?.Username
            };
        }
        public static WeatherForecast ToModel(WeatherForecastInputDto forecast)
        {
            return new WeatherForecast
            {
                Date = forecast.Date,
                Summary = forecast.Summary,
                TemperatureC = forecast.TemperatureC,
                UserId = forecast.UserId
            };
        }

        public static UserOutputDto ToDto(User user)
        {
            return new UserOutputDto
            {
                Id = user.Id,
                Username = user.Username
            };
        }

        public static User ToModel(UserInputDto input)
        {
            return new User
            {
                Username = input.Username,
                Password = input.Password
            };
        }
    }
}