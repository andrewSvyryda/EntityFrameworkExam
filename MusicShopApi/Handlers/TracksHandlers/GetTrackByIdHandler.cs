using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetTrackByIdHandler : IRequestHandler<GetTrackByIdQuery, TrackDTO>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetTrackByIdHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<TrackDTO> Handle(GetTrackByIdQuery request, CancellationToken cancellationToken)
        {
            await context.Tracks.Where(t => t.Id == request.Id).LoadAsync();
            return mapper.Map<TrackDTO>(context.Tracks.SingleOrDefault(t => t.Id == request.Id));
        }
    }
}
