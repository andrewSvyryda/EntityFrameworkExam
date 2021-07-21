using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetTracksByDiscIdHandler : IRequestHandler<GetTracksByDiscIdQuery, List<TrackDTO>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetTracksByDiscIdHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<List<TrackDTO>> Handle(GetTracksByDiscIdQuery request, CancellationToken cancellationToken)
        {
            await context.Tracks.Where((t) => t.DiscId == request.DiscId).LoadAsync();
            return mapper.Map<List<TrackDTO>>(context.Tracks.Where((t) => t.DiscId == request.DiscId));
        }
    }
}
