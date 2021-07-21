using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetSalesQuery : IRequest<List<SaleDTO>>
    {
    }
}
