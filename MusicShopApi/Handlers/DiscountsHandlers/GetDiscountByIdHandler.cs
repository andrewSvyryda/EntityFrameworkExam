using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetDiscountByIdHandler : IRequestHandler<GetDiscountByIdQuery, DiscountDTO>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetDiscountByIdHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<DiscountDTO> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken)
        {
            await context.Discounts.Where(d => d.Id == request.Id).LoadAsync();
            return mapper.Map<DiscountDTO>(context.Discounts.SingleOrDefault(d => d.Id == request.Id));
        }
    }
}
