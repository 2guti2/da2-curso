using Microsoft.AspNetCore.Mvc;
using ObligatorioDA2.Application.Contracts.Users;
using ObligatorioDA2.Application.Contracts.Users.Dtos;

namespace ObligatorioDA2.HttpApi.Controllers
{
    [ApiController]
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
    }
}