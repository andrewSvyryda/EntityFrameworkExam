using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetNewDiscsQuery : IRequest<List<DiscDTO>>
    {
        public int Count { get; }
        public GetNewDiscsQuery(int count)
        {
            Count = count;
        }
    }
}
