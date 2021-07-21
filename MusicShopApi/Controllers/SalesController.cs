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
    public class SalesController : ControllerBase
    {
        private readonly IMediator mediator;

        public SalesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var query = new GetSaleByIdQuery(Id);
            var result = await mediator.Send(query);
            return result.Price != 0 ? Ok(result) : NotFound();
        }

        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId(int UserId)
        {
            var query = new GetSalesByUserIdQuery(UserId);
            var result = await mediator.Send(query);
            return result.Count != 0 ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetSale()
        {
            var query = new GetSalesQuery();
            var result = await mediator.Send(query);
            return result.Count != 0 ? Ok(result) : NotFound();
        }

        [HttpPost("CreateSale")]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleCommand command, [FromServices] ICreateSaleService service)
        {
            var result = await service.CreateSale(command);
            if (result.Id == -1)
                return NotFound($"Discs with names ({string.Join(", ", result.Discs)}) is over(");
            else if (result.Id == -2)
                return NotFound("There are 0 discs in sale");
            else if (result.Id == -3)
                return NotFound("Discorrect user");
            return CreatedAtAction("GetSale", new { }, result);
        }

    }
}
