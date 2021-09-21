using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatorioDA2.Domain;
using ObligatorioDA2.EntityFrameworkCore.Contracts;

namespace ObligatorioDA2.EntityFrameworkCore.Tests
{
    [TestClass]
    public class BaseRepositoryTests
    {
        private readonly IRepository<WeatherForecast> _fakeRepo;

        public BaseRepositoryTests()
        {
            Context context = ContextFactory.GetInMemoryContext("InMemoryTestDb");
            context.WeatherForecasts.Add(new WeatherForecast
            {
                Summary = "hot",
                TemperatureC = 30
            });
            context.WeatherForecasts.Add(new WeatherForecast
            {
                Summary = "cold",
                TemperatureC = 12
            });
            context.SaveChanges();
            _fakeRepo = new FakeRepository(context);
        }

        [TestMethod]
        public void ReadAllWhere_IsSuccessful()
        {
            IEnumerable<WeatherForecast> hotForecasts = _fakeRepo.ReadAllWhere(f => f.Summary == "hot");
            Assert.AreEqual(1, hotForecasts.Count());
        }
    }
}
