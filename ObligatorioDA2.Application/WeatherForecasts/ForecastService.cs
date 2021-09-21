using System;
using System.Collections.Generic;
using System.Linq;
using ObligatorioDA2.Application.Contracts.WeatherForecasts;
using ObligatorioDA2.Application.Contracts.WeatherForecasts.Dtos;
using ObligatorioDA2.Domain;
using ObligatorioDA2.EntityFrameworkCore.Contracts;

namespace ObligatorioDA2.Application.WeatherForecasts
{
    public class ForecastService : IForecastService
    {
        private readonly IRepository<WeatherForecast> _weatherForecastsRepo;

        public ForecastService(IRepository<WeatherForecast> weatherForecastsRepo)
        {
            _weatherForecastsRepo = weatherForecastsRepo;
        }

        public IEnumerable<WeatherForecastOutputDto> ReadAll()
        {
            IEnumerable<WeatherForecast> forecasts = _weatherForecastsRepo.ReadAll();
            return forecasts.Select(Mapper.ToDto);
        }

        public WeatherForecastOutputDto Read(int id)
        {
            return Mapper.ToDto(_weatherForecastsRepo.Read(id));
        }

        public WeatherForecastOutputDto Create(WeatherForecastInputDto input)
        {
            WeatherForecast forecast = Mapper.ToModel(input);
            _weatherForecastsRepo.Create(forecast);
            return Read(forecast.Id);
        }

        public WeatherForecastOutputDto Update(int id, WeatherForecastInputDto input)
        {
            WeatherForecast forecast = Mapper.ToModel(input);
            forecast.Id = id;
            _weatherForecastsRepo.Update(forecast);
            return Read(forecast.Id);
        }

        public void Delete(int id)
        {
            WeatherForecast forecast = _weatherForecastsRepo.Read(id);
            Guard.Requires(() => forecast != null, "Forecast doesn't exist.");
            _weatherForecastsRepo.Delete(forecast ?? throw new InvalidOperationException());
        }

        public IEnumerable<WeatherForecastOutputDto> ReadAllWithSummary(string summary)
        {
            IEnumerable<WeatherForecast> forecasts = _weatherForecastsRepo.ReadAllWhere(f => f.Summary == summary);
            return forecasts.Select(Mapper.ToDto);
        }
    }
}