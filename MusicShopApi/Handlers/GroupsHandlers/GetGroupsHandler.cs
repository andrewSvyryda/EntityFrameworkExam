using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetGroupsHandler : IRequestHandler<GetGroupsQuery, List<GroupDTO>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetGroupsHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<GroupDTO>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {
            await context.Groups.LoadAsync();
            return mapper.Map<List<GroupDTO>>(context.Groups);
        }
    }
}
