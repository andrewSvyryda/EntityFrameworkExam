using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetUserByIdHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            await context.Users.Where(u => u.Id == request.Id).Include(u => u.Sales).LoadAsync();
            return mapper.Map<UserDTO>(context.Users.SingleOrDefault(u => u.Id == request.Id));
        }
    }
}
