using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetBestSellingDiscsQuery : IRequest<List<DiscDTO>>
    {
        public int Count { get; }
        public GetBestSellingDiscsQuery(int count)
        {
            Count = count;
        }
    }
}
