using System.Collections.Generic;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using ObligatorioDA2.Application.Contracts.Users;
using ObligatorioDA2.Application.Contracts.Users.Dtos;
using ObligatorioDA2.HttpApi.Filters;

namespace ObligatorioDA2.HttpApi.Controllers
{
    [ApiController]
    [ExceptionFilter]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<UserOutputDto> Create([FromBody] UserInputDto user)
        {
            UserOutputDto createdUser = _userService.Create(user);
            return Ok(createdUser);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserOutputDto>> Get([FromQuery(Name = "username")] string username)
        {
            return Ok(username.IsNullOrEmpty()
                ? _userService.ReadAll()
                : _userService.ReadAllWithUsername(username));
        }
    }
}