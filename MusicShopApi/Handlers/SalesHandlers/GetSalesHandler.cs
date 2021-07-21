using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetSalesHandler : IRequestHandler<GetSalesQuery, List<SaleDTO>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetSalesHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<SaleDTO>> Handle(GetSalesQuery request, CancellationToken cancellationToken)
        {
            await context.Sales.LoadAsync();
            return mapper.Map<List<SaleDTO>>(context.Sales);
        }
    }
}
