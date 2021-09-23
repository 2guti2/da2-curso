using Microsoft.AspNetCore.Mvc;
using ObligatorioDA2.Application.Contracts.Roles.Dtos;
using ObligatorioDA2.Application.Contracts.Users;

namespace ObligatorioDA2.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleAssignmentController : ControllerBase
    {
        private readonly IUserService _userService;

        public RoleAssignmentController(IUserService userService)
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