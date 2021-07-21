using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetDiscountsQuery : IRequest<List<DiscountDTO>>
    {
    }
}
