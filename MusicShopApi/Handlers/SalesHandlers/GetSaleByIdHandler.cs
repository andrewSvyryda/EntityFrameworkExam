using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetSaleByIdHandler : IRequestHandler<GetSaleByIdQuery, SaleDTO>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetSaleByIdHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<SaleDTO> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
        {
            await context.Sales.Where(s => s.Id == request.Id).LoadAsync();
            return mapper.Map<SaleDTO>(context.Sales.SingleOrDefault(s => s.Id == request.Id));
        }
    }
}
