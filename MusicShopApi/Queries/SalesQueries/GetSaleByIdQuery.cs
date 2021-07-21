using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetSaleByIdQuery : IRequest<SaleDTO>
    {
        public GetSaleByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
