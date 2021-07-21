using MediatR;
using System.Collections.Generic;

namespace MusicShopApi
{
    public class GetDiscountsByIdRangeQuery : IRequest<List<Discount>>
    {
        public GetDiscountsByIdRangeQuery(ICollection<int> idRange)
        {
            IdRange = idRange;
        }
        public ICollection<int> IdRange { get; }
    }
}
