using AutoMapper;
using MediatR;
using MusicShopApi.Commands;
using System.Threading.Tasks;

namespace MusicShopApi.Services
{
    public interface IChangeDiscService
    {
        public Task<DiscDTO> ChangeDisc(ChangeDiscCommand command);
    }
    public class ChangeDiscService : IChangeDiscService
    {
        private readonly IMediator mediator;

        public ChangeDiscService(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<DiscDTO> ChangeDisc(ChangeDiscCommand command)
        {
            var query = new GetDiscountsByIdRangeQuery(command.DiscountsId);
            command.Discounts = await mediator.Send(query);
            return await mediator.Send(new GetDiscDTOByIdQuery(await mediator.Send(command)));
        }
    }
}
