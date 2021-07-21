using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<UserDTO>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetUsersHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<UserDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            await context.Users.LoadAsync();
            return mapper.Map<List<UserDTO>>(context.Users);
        }
    }
}
