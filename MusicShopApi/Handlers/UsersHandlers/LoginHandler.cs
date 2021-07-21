using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class LoginHandler : IRequestHandler<LoginQuery, UserDTO>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public LoginHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<UserDTO> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            User user = await context.Users.SingleOrDefaultAsync(u => u.Login == request.Login);
            if (user == null)
                return new UserDTO { Id = -2 };
            if(user.Password != request.Password)
                return new UserDTO { Id = -1 };
            return mapper.Map<UserDTO>(user);
        }
    }
}
