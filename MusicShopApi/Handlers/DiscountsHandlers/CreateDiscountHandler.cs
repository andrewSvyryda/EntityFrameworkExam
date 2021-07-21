using AutoMapper;
using MediatR;
using MusicShopApi.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers.GenresHandlers
{
    public class CreateDiscountHandler : IRequestHandler<CreateDiscountCommand, DiscountDTO>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public CreateDiscountHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<DiscountDTO> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            Discount Discount = (await context.Discounts.AddAsync(new Discount { Name = request.Name, DateFrom = request.DateFrom, DateTo = request.DateTo, DiscountValue = request.DiscountValue })).Entity;
            await context.SaveChangesAsync();
            return mapper.Map<DiscountDTO>(Discount);
        }
    }
}
