using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ObligatorioDA2.HttpApi.Controllers
{
    public class WeatherForecastAuthorizationFilter: Attribute, IAuthorizationFilter
    {

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string token = context.HttpContext.Request.Headers["auth"];
        if (token == null)
        {
            context.Result = new ContentResult()
            {
                StatusCode = 401,
                Content =  "No esta autorizado"
            };
            return;
            }
        }
    }
}
