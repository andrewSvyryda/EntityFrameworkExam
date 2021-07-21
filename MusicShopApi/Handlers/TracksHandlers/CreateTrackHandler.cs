using AutoMapper;
using MediatR;
using MusicShopApi.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers.GenresHandlers
{
    public class CreateTrackHandler : IRequestHandler<CreateTrackCommand, TrackDTO>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public CreateTrackHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<TrackDTO> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
        {
            Track Track = (await context.Tracks.AddAsync(new Track { Name = request.Name, Duration = TimeSpan.FromSeconds(request.DurationInSec), DiscId = request.DiscId })).Entity;
            await context.SaveChangesAsync();
            return mapper.Map<TrackDTO>(Track);
        }
    }
}
