using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetDiscDTOByIdHandler : IRequestHandler<GetDiscDTOByIdQuery, DiscDTO>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetDiscDTOByIdHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<DiscDTO> Handle(GetDiscDTOByIdQuery request, CancellationToken cancellationToken)
        {
            await context.Discs.Where(d => d.Id == request.Id).Include(d => d.Publisher).Include(d => d.Genre).Include(d => d.Group).Include(d => d.Discounts).LoadAsync();
            return mapper.Map<DiscDTO>(context.Discs.SingleOrDefault(d => d.Id == request.Id));
        }
    }
    public class GetDiscByIdHandler : IRequestHandler<GetDiscByIdQuery, Disc>
    {
        private readonly MusicalShopModel context;

        public GetDiscByIdHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
        }

        public async Task<Disc> Handle(GetDiscByIdQuery request, CancellationToken cancellationToken)
        {
            await context.Discs.Where(d => d.Id == request.Id).Include(d => d.Publisher).Include(d => d.Genre).Include(d => d.Group).Include(d => d.Discounts).LoadAsync();
            return context.Discs.SingleOrDefault(d => d.Id == request.Id);
        }
    }
}
