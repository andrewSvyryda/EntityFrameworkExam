using AutoMapper;
using MediatR;
using MusicShopApi.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers.GenresHandlers
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, SaleDTO>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public CreateSaleHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<SaleDTO> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            Sale Sale = (await context.Sales.AddAsync(new Sale { Price = request.Price, SaleDate = request.SaleDate, UserId = request.UserId, Discs = request.Discs })).Entity;
            
            await context.SaveChangesAsync();
            return mapper.Map<SaleDTO>(Sale);
        }
    }
}
