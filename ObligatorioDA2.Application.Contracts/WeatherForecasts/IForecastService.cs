using System.Collections.Generic;
using ObligatorioDA2.Application.Contracts.WeatherForecasts.Dtos;

namespace ObligatorioDA2.Application.Contracts.WeatherForecasts
{
    public interface IForecastService
    {
        IEnumerable<WeatherForecastOutputDto> ReadAll();

        WeatherForecastOutputDto Read(int id);

        WeatherForecastOutputDto Create(WeatherForecastInputDto forecast);

        WeatherForecastOutputDto Update(int id, WeatherForecastInputDto forecast);

        public void Delete(int id);

        IEnumerable<WeatherForecastOutputDto> ReadAllWithSummary(string summary);
    }
}