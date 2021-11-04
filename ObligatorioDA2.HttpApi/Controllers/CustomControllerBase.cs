using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ObligatorioDA2.HttpApi.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        protected string Username => (string)HttpContext.Items["username"];
    }
}