using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ObligatorioDA2.Application.Contracts.Users;

namespace ObligatorioDA2.HttpApi.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var userService = (IUserService) context.HttpContext.RequestServices.GetService(typeof(IUserService));

                string token = context.HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];

                byte[] valueBytes = Convert.FromBase64String(token);
                string decodedToken = Encoding.UTF8.GetString(valueBytes);

                string[] userPass = decodedToken.Split(":");
                string username = userPass[0];
                string password = userPass[1];

                bool isAuthorized = userService.IsAuthorized(username, password);

                if (!isAuthorized)
                {
                    Unauthorized(context);
                }
            }
            catch (Exception)
            {
                Unauthorized(context);
            }
        }

        private void Unauthorized(AuthorizationFilterContext context)
        {
            context.Result = new ContentResult
            {
                StatusCode = 401,
                Content = "Unauthorized"
            };
        }
    }
}