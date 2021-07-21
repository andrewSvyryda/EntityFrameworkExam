using AutoMapper;
using MediatR;
using MusicShopApi.Commands;
using MusicShopApi.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopApi.Services
{
    public interface ICreateSaleService
    {
        public Task<SaleDTO> CreateSale(CreateSaleCommand command);
    }
    public class CreateSaleService : ICreateSaleService
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public CreateSaleService(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        public async Task<SaleDTO> CreateSale(CreateSaleCommand command)
        {
            var query = new GetDiscsByIdRangeQuery(command.DiscsId);
            command.Discs = (await mediator.Send(query));
            if(command.Discs.Count == 0)
                return new SaleDTO { Id = -2 };
            foreach (Disc disc in command.Discs)
            {
                if (disc.Count == 0)
                    return new SaleDTO { Id = -1, Discs = mapper.Map<List<DiscDTO>>(command.Discs.Where(d => d.Count == 0)) };
                --disc.Count;
            }
            UserDTO user = await mediator.Send(new GetUserByIdQuery(command.UserId));
            if(user == null)
                return new SaleDTO { Id = -3 };
            command.Price = (int)(command.Discs.Select(d => d.Price * DiscountsCounter.GetComplextDiscountByDiscountsList(mediator.Send(new GetDiscountsByDiscsQuery(d.Id)).Result)).Sum() * (1 - (float)(await mediator.Send(new GetUserByIdQuery(command.UserId))).CurrentDiscount / 100));
            SaleDTO tmp = await mediator.Send(command);

            if (user.Sales.Select(s => s.Price).Sum() > 1000)
            {
                await mediator.Send(new ChangeUserCommand { CurrentDiscount = 5, Id = user.Id });
            }
            else if (user.Sales.Select(s => s.Price).Sum() > 2000)
            {
                await mediator.Send(new ChangeUserCommand { CurrentDiscount = 10, Id = user.Id });
            }
            else if (user.Sales.Select(s => s.Price).Sum() > 3000)
            {
                await mediator.Send(new ChangeUserCommand { CurrentDiscount = 14, Id = user.Id });
            }
            else if (user.Sales.Select(s => s.Price).Sum() > 4000)
            {
                await mediator.Send(new ChangeUserCommand { CurrentDiscount = 17, Id = user.Id });
            }
            return tmp;
        }
    }
}
