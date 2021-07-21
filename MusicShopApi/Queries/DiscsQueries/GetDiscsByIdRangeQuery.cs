using MediatR;
using System.Collections.Generic;

namespace MusicShopApi
{
    public class GetDiscsByIdRangeQuery : IRequest<List<Disc>>
    {
        public GetDiscsByIdRangeQuery(ICollection<int> idRange)
        {
            IdRange = idRange;
        }
        public ICollection<int> IdRange { get; }
    }
}
