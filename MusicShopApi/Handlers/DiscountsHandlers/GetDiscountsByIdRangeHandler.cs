using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetDiscountsByIdRangeHandler : IRequestHandler<GetDiscountsByIdRangeQuery, List<Discount>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetDiscountsByIdRangeHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<Discount>> Handle(GetDiscountsByIdRangeQuery request, CancellationToken cancellationToken)
        {
            await context.Discounts.Where(d => request.IdRange.Contains(d.Id)).LoadAsync();
            return context.Discounts.Where(d => request.IdRange.Contains(d.Id)).ToList();
        }
    }


}
