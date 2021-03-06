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
    public class GetDiscsByGroupHandler : IRequestHandler<GetDiscsByGroupQuery, List<DiscDTO>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetDiscsByGroupHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<DiscDTO>> Handle(GetDiscsByGroupQuery request, CancellationToken cancellationToken)
        {
            await context.Discs.Where(d => d.GroupId == request.GroupId).Include(d => d.Publisher).Include(d => d.Genre).Include(d => d.Group).Include(d => d.Discounts).LoadAsync();
            return mapper.Map<List<DiscDTO>>(context.Discs.Where(d => d.GroupId == request.GroupId));
        }
    }
}
