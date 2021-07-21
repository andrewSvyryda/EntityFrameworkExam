using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetSalesByUserIdQuery : IRequest<List<SaleDTO>>
    {
        public GetSalesByUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}
