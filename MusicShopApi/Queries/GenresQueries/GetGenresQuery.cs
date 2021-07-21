using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetGenresQuery : IRequest<List<GenreDTO>>
    {
    }
}
