using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ObligatorioDA2.HttpApi.Controllers
{
    public class ResponseResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            //manejo de resp
            ResponseDTO response = new ResponseDTO()
            {
                Code = 0,
                Content = ((ObjectResult)context.Result).Value
            };
            context.Result = new ObjectResult(response);
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            //no permite cambiar resp. solo lee
        }
    }
}