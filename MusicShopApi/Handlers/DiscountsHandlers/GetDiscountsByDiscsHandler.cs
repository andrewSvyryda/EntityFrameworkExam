using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetDiscountsByDiscsHandler : IRequestHandler<GetDiscountsByDiscsQuery, List<DiscountDTO>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetDiscountsByDiscsHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<DiscountDTO>> Handle(GetDiscountsByDiscsQuery request, CancellationToken cancellationToken)
        {
            await context.Discs.Where(d => d.Id == request.DiscId).Include(d => d.Discounts).LoadAsync();
            return mapper.Map<List<DiscountDTO>>(context.Discs.Single(d => d.Id == request.DiscId).Discounts);
        }
    }
}
