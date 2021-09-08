using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ObligatorioDA2.Application.Contracts.WeatherForecasts;
using ObligatorioDA2.Application.Contracts.WeatherForecasts.Dtos;
using ObligatorioDA2.HttpApi.Controllers;

namespace ObligatorioDA2.HttpApi.Tests
{
    [TestClass]
    public class WeatherForecastControllerTests
    {
        private readonly List<WeatherForecastOutputDto> _all;
        private readonly IEnumerable<WeatherForecastOutputDto> _onlyHot;

        public WeatherForecastControllerTests()
        {
            _all = new List<WeatherForecastOutputDto>
            {
                new() {Summary = "hot"},
                new() {Summary = "cold"}
            };
            _onlyHot = _all.Where(f => f.Summary == "hot");
        }

        [TestMethod]
        public void ReadAll_IsSuccessful()
        {
            var mock = new Mock<IForecastService>(MockBehavior.Strict);
            mock.Setup(m => m.ReadAll()).Returns(_all);

            var controller = new WeatherForecastController(mock.Object);

            ActionResult<IEnumerable<WeatherForecastOutputDto>> actionResult = controller.ReadAll(null);
            var result = actionResult.Result as OkObjectResult;

            mock.VerifyAll();
            Assert.AreEqual(result?.Value, _all);
        }

        [TestMethod]
        public void ReadAll_PassingSummary_IsSuccessful()
        {
            var mock = new Mock<IForecastService>(MockBehavior.Strict);
            mock.Setup(m => m.ReadAllWithSummary("hot")).Returns(_onlyHot);

            var controller = new WeatherForecastController(mock.Object);

            ActionResult<IEnumerable<WeatherForecastOutputDto>> actionResult = controller.ReadAll("hot");
            var result = actionResult.Result as OkObjectResult;

            mock.VerifyAll();
            Assert.AreEqual(result?.Value, _onlyHot);
        }
    }
}
