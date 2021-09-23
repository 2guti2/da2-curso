using Microsoft.AspNetCore.Mvc;
using ObligatorioDA2.Application.Contracts.Users;
using ObligatorioDA2.HttpApi.Filters;

namespace ObligatorioDA2.HttpApi.Controllers
{
    [ApiController]
    [ExceptionFilter]
    [Route("[controller]")]
    public class RoleAssignmentController : ControllerBase
    {
        private readonly IUserService _userService;

        public RoleAssignmentController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] RoleAssignmentDto assignment)
        {
            _userService.Assign(assignment.UserId, assignment.Role);
            return Ok();
        }
    }

    public class RoleAssignmentDto
    {
        public int UserId { get; set; }
        public string Role { get; set; }
    }
}