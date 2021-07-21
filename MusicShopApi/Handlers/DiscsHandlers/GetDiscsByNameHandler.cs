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
    public class GetDiscsByNameHandler : IRequestHandler<GetDiscsByNameQuery, List<DiscDTO>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetDiscsByNameHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<DiscDTO>> Handle(GetDiscsByNameQuery request, CancellationToken cancellationToken)
        {
            await context.Discs.Where(d => d.Name.Contains(request.DiscName)).Include(d => d.Publisher).Include(d => d.Genre).Include(d => d.Group).Include(d => d.Discounts).LoadAsync();
            return mapper.Map<List<DiscDTO>>(context.Discs.Where(d => d.Name.Contains(request.DiscName)));
        }
    }
    /*
    public class GetDiscsByNameHandler : IRequestHandler<GetDiscsByNameQuery, List<DiscDTO>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetDiscsByNameHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<DiscDTO>> Handle(GetDiscsByNameQuery request, CancellationToken cancellationToken)
        {
            await context.Discs.Where(d => d.Name.Contains(request.DiscName)).LoadAsync();
            return mapper.Map<List<DiscDTO>>(context.Discs.Where(d => d.Name.Contains(request.DiscName)));
        }
    }*/
}
