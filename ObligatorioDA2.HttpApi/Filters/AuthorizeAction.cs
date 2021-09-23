using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ObligatorioDA2.Application.Contracts.Users;

namespace ObligatorioDA2.HttpApi.Filters
{
    public class AuthorizeAction : Attribute, IAuthorizationFilter
    {
        private string _action;

        public AuthorizeAction(string action)
        {
            _action = action;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userService = (IUserService)context.HttpContext.RequestServices.GetService(typeof(IUserService));
            var username = (string)context.HttpContext.Items["username"];

            if (!userService.CanPerform(username, _action))
            {
                context.Result = new ContentResult
                {
                    StatusCode = 401,
                    Content = "Unauthorized"
                };
            }
        }
    }
}