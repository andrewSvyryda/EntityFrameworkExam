using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopApi.Queries
{
    public class GetTracksQuery : IRequest<List<TrackDTO>>
    {
    }
    public class GetTrackByIdQuery : IRequest<TrackDTO>
    {
        public GetTrackByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
