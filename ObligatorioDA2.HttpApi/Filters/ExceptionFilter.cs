using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ObligatorioDA2.Domain.Exceptions;

namespace ObligatorioDA2.HttpApi.Controllers
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ContentResult()
            {
                StatusCode = 500,
                Content = "Internal error"
            };

            if (context.Exception is GuardClauseException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 422,
                    Content = "Entity doesn't exist." //es valido eliminar el de service e insertar error aca.
                };
            }
        }
    }
}
