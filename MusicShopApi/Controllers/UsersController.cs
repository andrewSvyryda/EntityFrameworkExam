using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicShopApi.Commands;
using MusicShopApi.Queries;
using MusicShopApi.Services;
using System.Threading.Tasks;

namespace MusicShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var query = new GetUserByIdQuery(Id);
            UserDTO result = await mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var query = new GetUsersQuery();
            var result = await mediator.Send(query);
            return result.Count != 0 ? Ok(result) : NotFound();
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await mediator.Send(command);
            return CreatedAtAction("GetUser", new { }, result);
        }
        [HttpPut("ChangeUser")]
        public async Task<IActionResult> ChangeUser([FromBody] ChangeUserCommand command, [FromServices] IChangeUserService service)
        {
            var result = await service.ChangeUser(command);
            if (result == -1)
                return NotFound("Discorrect password");
            if (result == -2)
                return NotFound("Discorrect login");
            return CreatedAtAction("GetUser", new { }, result);
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login(string login, string password)
        {
            var query = new LoginQuery(login, password);
            var result = await mediator.Send(query);
            if (result.Id == -1)
                return NotFound("Discorrect password");
            if (result.Id == -2)
                return NotFound("Discorrect login");
            return Ok(result);
        }


    }
}
