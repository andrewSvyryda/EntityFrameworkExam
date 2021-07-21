using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetGroupByIdHandler : IRequestHandler<GetGroupByIdQuery, GroupDTO>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetGroupByIdHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GroupDTO> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
        {
            await context.Groups.Where(g => g.Id == request.Id).LoadAsync();
            return mapper.Map<GroupDTO>(context.Groups.SingleOrDefault(g => g.Id == request.Id));
        }
    }
}
