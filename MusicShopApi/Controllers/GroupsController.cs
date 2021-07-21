using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicShopApi.Commands;
using MusicShopApi.Queries;
using System.Threading.Tasks;

namespace MusicShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IMediator mediator;

        public GroupsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var query = new GetGroupByIdQuery(Id);
            var result = await mediator.Send(query);
            return result.Name != null ? Ok(result) : NotFound();
        }

        [HttpGet("GetBest")]
        public async Task<IActionResult> GetBest(int Count)
        {
            var query = new GetBestGroupsQuery(Count);
            var result = await mediator.Send(query);
            return result.Count != 0 ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetGroup()
        {
            var query = new GetGroupsQuery();
            var result = await mediator.Send(query);
            return result.Count != 0 ? Ok(result) : NotFound();
        }
        [HttpPost("CreateGroup")]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupCommand command)
        {
            var result = await mediator.Send(command);
            return CreatedAtAction("GetGroup", new { }, result);
        }

    }
}
