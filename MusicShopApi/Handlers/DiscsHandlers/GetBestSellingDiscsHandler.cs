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
    public class GetBestSellingDiscsHandler : IRequestHandler<GetBestSellingDiscsQuery, List<DiscDTO>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetBestSellingDiscsHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<List<DiscDTO>> Handle(GetBestSellingDiscsQuery request, CancellationToken cancellationToken)
        {
            await context.Discs.OrderByDescending(d => d.Sales.Count).Take(request.Count).Include(d => d.Publisher).Include(d => d.Genre).Include(d => d.Group).Include(d => d.Discounts).LoadAsync();
            return mapper.Map<List<DiscDTO>>(context.Discs.OrderByDescending(d => d.Sales.Count).Take(request.Count));
        }
    }
}
