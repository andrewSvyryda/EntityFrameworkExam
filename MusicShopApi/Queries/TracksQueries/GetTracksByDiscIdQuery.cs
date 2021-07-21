using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetTracksByDiscIdQuery : IRequest<List<TrackDTO>>
    {
        public int DiscId { get; }
        public GetTracksByDiscIdQuery(int id)
        {
            DiscId = id;
        }
    }
}
