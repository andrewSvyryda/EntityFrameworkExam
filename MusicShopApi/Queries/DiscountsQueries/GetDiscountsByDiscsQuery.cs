using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetDiscountsByDiscsQuery : IRequest<List<DiscountDTO>>
    {
        public int DiscId { get; }
    public GetDiscountsByDiscsQuery(int discId)
    {
            DiscId = discId;
    }
}
}
