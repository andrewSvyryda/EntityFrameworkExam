using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetPublisherByIdHandler : IRequestHandler<GetPublisherByIdQuery, PublisherDTO>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetPublisherByIdHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PublisherDTO> Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken)
        {
            await context.Publishers.Where(p => p.Id == request.Id).LoadAsync();
            return mapper.Map<PublisherDTO>(context.Publishers.SingleOrDefault(p => p.Id == request.Id));
        }
    }
}
