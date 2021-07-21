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
    public class DiscountsController : ControllerBase
    {
        private readonly IMediator mediator;

        public DiscountsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetByDiscId")]
        public async Task<IActionResult> GetByDiscId(int DiscId)
        {
            var query = new GetDiscountsByDiscsQuery(DiscId);
            var result = await mediator.Send(query);
            return result.Count != 0 ? Ok(result) : NotFound();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var query = new GetDiscountByIdQuery(Id);
            var result = await mediator.Send(query);
            return result.Name != null ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetDiscount()
        {
            var query = new GetDiscountsQuery();
            var result = await mediator.Send(query);
            return result.Count != 0 ? Ok(result) : NotFound();
        }
        [HttpPost("CreateDiscount")]
        public async Task<IActionResult> CreateDiscount([FromBody] CreateDiscountCommand command)
        {
            var result = await mediator.Send(command);
            return CreatedAtAction("GetDiscount", new { }, result);
        }

    }
}
