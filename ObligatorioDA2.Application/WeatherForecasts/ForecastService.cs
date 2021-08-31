using System;
using System.Collections.Generic;
using ObligatorioDA2.Application.Interface;
using ObligatorioDA2.Domain;
using ObligatorioDA2.Repositories.Interface;

namespace ObligatorioDA2.Application.WeatherForecasts
{
    public class ForecastService : IService<WeatherForecast>
    {
        private IRepository<WeatherForecast> repository;

        public ForecastService(IRepository<WeatherForecast> repository)
        {
            this.repository = repository;
        }

        public WeatherForecast Create(WeatherForecast forecast)
        {
            repository.Add(forecast);
            repository.Save();
            return forecast;
        }

        public void Delete(int id)
        {
            WeatherForecast forecast = repository.Get(id);
            ThrowErrorIfItsNull(forecast);
            repository.Delete(forecast);
            repository.Save();
        }

        public WeatherForecast Update(int id, WeatherForecast forecast)
        {
            ThrowErrorIfItsNull(repository.Get(id));
            WeatherForecast forecastToUpdate = forecast;
            repository.Update(forecast);
            repository.Save();
            return forecast;
        }

        public WeatherForecast Get(int id)
        {
            return repository.Get(id);
        }

        public IEnumerable<WeatherForecast> GetAll()
        {
            return repository.GetAll();
        }

        private static void ThrowErrorIfItsNull(WeatherForecast forecast)
        {
            if (forecast == null)
            {
                throw new ArgumentException("Invalid id");
            }
        }
    }
}