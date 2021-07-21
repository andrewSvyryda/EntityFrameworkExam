using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetPublishersHandler : IRequestHandler<GetPublishersQuery, List<PublisherDTO>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetPublishersHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<PublisherDTO>> Handle(GetPublishersQuery request, CancellationToken cancellationToken)
        {
            await context.Publishers.LoadAsync();
            return mapper.Map<List<PublisherDTO>>(context.Publishers);
        }
    }
}
