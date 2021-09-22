using System.Collections.Generic;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using ObligatorioDA2.Application.Contracts.WeatherForecasts;
using ObligatorioDA2.Application.Contracts.WeatherForecasts.Dtos;
using ObligatorioDA2.Domain.Exceptions;

namespace ObligatorioDA2.HttpApi.Controllers
{
    public class ResponseDTO 
    {
        public object Content { get; set; }
        public int Code { get; set; }
    }
}
