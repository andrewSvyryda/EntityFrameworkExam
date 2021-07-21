using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetSalesByUserIdHandler : IRequestHandler<GetSalesByUserIdQuery, List<SaleDTO>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetSalesByUserIdHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<SaleDTO>> Handle(GetSalesByUserIdQuery request, CancellationToken cancellationToken)
        {
            await context.Sales.Where(s => s.UserId == request.UserId).LoadAsync();
            return mapper.Map<List<SaleDTO>>(context.Sales.Where(s => s.UserId == request.UserId));
        }
    }
}
