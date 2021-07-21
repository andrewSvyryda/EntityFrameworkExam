using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicShopApi.Queries;
using MediatR;
using MusicShopApi.Commands;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly IMediator mediator;

        public TracksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetByDiscId")]
        public async Task<IActionResult> GetByDiscId(int DiscId)
        {
            var query = new GetTracksByDiscIdQuery(DiscId);
            var result = await mediator.Send(query);
            return result.Count != 0 ? Ok(result) : NotFound();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var query = new GetTrackByIdQuery(Id);
            var result = await mediator.Send(query);
            if (result == null || result.Name != null)
                NotFound();
            return !string.IsNullOrWhiteSpace(result.Name) ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetTrack()
        {
            var query = new GetTracksQuery();
            var result = await mediator.Send(query);
            return result.Count != 0 ? Ok(result) : NotFound();
        }
        [HttpPost("CreateTrack")]
        public async Task<IActionResult> CreateTrack([FromBody] CreateTrackCommand command)
        {
            var result = await mediator.Send(command);
            return CreatedAtAction("GetTrack", new { }, result);
        }

    }
}
