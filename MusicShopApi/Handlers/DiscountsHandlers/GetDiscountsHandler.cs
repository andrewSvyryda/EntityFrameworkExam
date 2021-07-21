using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetDiscountsHandler : IRequestHandler<GetDiscountsQuery, List<DiscountDTO>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetDiscountsHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<DiscountDTO>> Handle(GetDiscountsQuery request, CancellationToken cancellationToken)
        {
            await context.Discounts.LoadAsync();
            return mapper.Map<List<DiscountDTO>>(context.Discounts);
        }
    }
}
