using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ObligatorioDA2.Domain.Exceptions;

namespace ObligatorioDA2.HttpApi.Filters
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ContentResult
            {
                StatusCode = 500,
                Content = context.Exception.Message
            };

            if (context.Exception is GuardClauseException e)
            {
                context.Result = new ContentResult
                {
                    StatusCode = 400,
                    Content = e.Message
                };
            }
        }
    }
}