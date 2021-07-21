using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetDiscsByIdRangeHandler : IRequestHandler<GetDiscsByIdRangeQuery, List<Disc>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetDiscsByIdRangeHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<Disc>> Handle(GetDiscsByIdRangeQuery request, CancellationToken cancellationToken)
        {
            await context.Discs.Where(d => request.IdRange.Contains(d.Id)).Include(d => d.Publisher).Include(d => d.Genre).Include(d => d.Group).Include(d => d.Discounts).LoadAsync();
            return context.Discs.Where(d => request.IdRange.Contains(d.Id)).ToList();
        }
    }


}
