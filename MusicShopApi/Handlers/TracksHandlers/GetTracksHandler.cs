using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetTracksHandler : IRequestHandler<GetTracksQuery, List<TrackDTO>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetTracksHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<TrackDTO>> Handle(GetTracksQuery request, CancellationToken cancellationToken)
        {
            await context.Tracks.LoadAsync();
            return mapper.Map<List<TrackDTO>>(context.Tracks);
        }
    }
}
