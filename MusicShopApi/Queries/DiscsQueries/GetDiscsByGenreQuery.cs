using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetDiscsByGenreQuery : IRequest<List<DiscDTO>>
    {
        public int GenreId { get; }
        public GetDiscsByGenreQuery(int Id)
        {
            GenreId = Id;
        }
    }
}
