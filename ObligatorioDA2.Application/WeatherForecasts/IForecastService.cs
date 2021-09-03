using System.Collections.Generic;
using ObligatorioDA2.Application.WeatherForecasts.Dtos;

namespace ObligatorioDA2.Application.WeatherForecasts
{
    public interface IForecastService
    {
        IEnumerable<WeatherForecastOutputDto> ReadAll();

        WeatherForecastOutputDto Read(int id);

        WeatherForecastOutputDto Create(WeatherForecastInputDto forecast);

        WeatherForecastOutputDto Update(WeatherForecastInputDto forecast);

        public void Delete(int id);
    }
}