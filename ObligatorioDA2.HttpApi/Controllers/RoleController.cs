using Microsoft.AspNetCore.Mvc;
using ObligatorioDA2.Application.Contracts.Roles.Dtos;
using ObligatorioDA2.Application.Contracts.Users;

namespace ObligatorioDA2.HttpApi.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IUserService _userService;

        public RoleController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost]
        public ActionResult<RoleDto> Create([FromBody] RoleDto role)
        {
            _userService.Assign(role);
            return Ok(role);
        }
    }
}