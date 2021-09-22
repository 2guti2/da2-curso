﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ObligatorioDA2.HttpApi.Controllers
{
    public class CustomActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) {}
        public void OnActionExecuted(ActionExecutedContext context)
        {
            timer.Stop();
            string result = " Tiempo de ejecucion: " + $"{timer.Elapsed.TotalMilliseconds} ms";
            ((ObjectResult)context.Result).Value = result;
        }
    }
}
