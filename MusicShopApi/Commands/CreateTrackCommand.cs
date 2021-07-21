using MediatR;
using System;

namespace MusicShopApi.Commands
{
    public class CreateTrackCommand : IRequest<TrackDTO>
    {
        public string Name { get; set; }
        public int DurationInSec { get; set; }
        public int DiscId { get; set; }
    }
    
    /*
    public class CreateGenreCommand : IRequest<GenreDTO>
    {
        public string GenreName { get; set; }
    }*/
}
