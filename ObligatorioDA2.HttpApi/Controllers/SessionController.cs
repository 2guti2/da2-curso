using Microsoft.AspNetCore.Mvc;
using ObligatorioDA2.Application.Contracts.Users;
using ObligatorioDA2.Application.Contracts.Users.Dtos;
using ObligatorioDA2.HttpApi.Filters;

namespace ObligatorioDA2.HttpApi.Controllers
{    
    [ApiController]
    [ExceptionFilter]
    [Route("[controller]")]
    public class SessionController : CustomControllerBase
    {
        private readonly IUserService _userService;

        public SessionController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        public ActionResult<LoginOutputDto> Create([FromBody] LoginInputDto input)
        {
            return Ok(_userService.CreateSession(input));
        }
    }
}