using MediatR;
using Microsoft.AspNetCore.Mvc;
using MusicShopApi.Commands;
using MusicShopApi.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IMediator mediator;

        public GenresController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var query = new GetGenreByIdQuery(Id);
            var result = await mediator.Send(query);
            return result.Name != null ? Ok(result) : NotFound();
        }
        [HttpGet("GetBestGenres")]
        public async Task<IActionResult> GetBestGenres(int count, TimeSection section)
        {
            var query = new GetBestGenresByTimeSectionQuery(section, count);
            var result = await mediator.Send(query);
            return result.Count != 0 ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetGenre()
        {
            var query = new GetGenresQuery();
            var result = await mediator.Send(query);
            return result.Count != 0 ? Ok(result) : NotFound();
        }
        [HttpPost("CreateGenre")]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreCommand command)
        {
            var result = await mediator.Send(command);
            return CreatedAtAction("GetGenre", new { }, result);
        }

    }
}
