using AutoMapper;
using MediatR;
using MusicShopApi.Commands;
using System.Threading.Tasks;

namespace MusicShopApi.Services
{
    public interface ICreateDiscService
    {
        public Task<DiscDTO> CreateDisc(CreateDiscCommand command);
    }
    public class CreateDiscService : ICreateDiscService
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public CreateDiscService(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        public async Task<DiscDTO> CreateDisc(CreateDiscCommand command)
        {
            var query = new GetDiscountsByIdRangeQuery(command.DiscountsId);
            command.Discounts = await mediator.Send(query);
            return await mediator.Send(new GetDiscDTOByIdQuery(await mediator.Send(command)));
        }
    }


}
