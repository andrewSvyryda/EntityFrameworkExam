using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicShopApi.Queries;
using MediatR;
using MusicShopApi.Commands;
using MusicShopApi.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscsController : ControllerBase
    {
        private readonly IMediator mediator;

        public DiscsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiscs()
        {
            var query = new GetDiscsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("BestSellingDiscs")]
        public async Task<IActionResult> GetBest(int Count)
        {
            var query = new GetBestSellingDiscsQuery(Count);
            var result = await mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("GetNewDiscs")]
        public async Task<IActionResult> GetNewDiscs(int Count)
        {
            var query = new GetNewDiscsQuery(Count);
            var result = await mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var query = new GetDiscDTOByIdQuery(Id);
            var result = await mediator.Send(query);
            return result.Name != null ? Ok(result) : NotFound();
        }
        [HttpGet("GetByGenreId")]
        public async Task<IActionResult> GetByGenreId(int Id)
        {
            var query = new GetDiscsByGenreQuery(Id);
            var result = await mediator.Send(query);
            return result.Count != 0 ? Ok(result) : NotFound();
        }
        [HttpGet("GetByGroupId")]
        public async Task<IActionResult> GetByGroupId(int Id)
        {
            var query = new GetDiscsByGroupQuery(Id);
            var result = await mediator.Send(query);
            return result.Count != 0 ? Ok(result) : NotFound();
        }
        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName(string Name)
        {
            var query = new GetDiscsByNameQuery(Name);
            var result = await mediator.Send(query);
            return result.Count != 0 ? Ok(result) : NotFound();
        }

        [HttpPost("CreateDisc")]
        public async Task<IActionResult> CreateDisc([FromBody] CreateDiscCommand command, [FromServices] ICreateDiscService service)
        {
            var result = await service.CreateDisc(command);
            return CreatedAtAction("GetDiscs", new { id = 9 }, result);
        }

        [HttpPut("RestoreDiscCount")]
        public async Task<IActionResult> RestoreDiscCount([FromBody] RestoreDiscsCountCommand command, [FromServices] IRestoreDiscsCountService service)
        {
            var result = await service.RestoreDiscs(command);
            return Ok(result);
        }

        [HttpPut("ChangeDisc")]
        public async Task<IActionResult> ChangeDisc([FromBody] ChangeDiscCommand command, [FromServices] IChangeDiscService service)
        {
            var result = await service.ChangeDisc(command);
            return Ok(result);
        }
    }

}
