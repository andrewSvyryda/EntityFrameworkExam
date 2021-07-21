using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicShopApi.Commands;
using MusicShopApi.Queries;
using System.Threading.Tasks;

namespace MusicShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IMediator mediator;

        public PublishersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var query = new GetPublisherByIdQuery(Id);
            var result = await mediator.Send(query);
            return result.Name != null ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetPublisher()
        {
            var query = new GetPublishersQuery();
            var result = await mediator.Send(query);
            return result.Count != 0 ? Ok(result) : NotFound();
        }
        [HttpPost("CreatePublisher")]
        public async Task<IActionResult> CreatePublisher([FromBody] CreatePublisherCommand command)
        {
            var result = await mediator.Send(command);
            return CreatedAtAction("GetPublisher", new { }, result);
        }

    }
}
