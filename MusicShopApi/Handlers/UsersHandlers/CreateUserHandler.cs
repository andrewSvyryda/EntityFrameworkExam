using AutoMapper;
using MediatR;
using MusicShopApi.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers.GenresHandlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDTO>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public CreateUserHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User User = (await context.Users.AddAsync(new User { Name = request.Name, Login = request.Login, Password = request.Password })).Entity;
            await context.SaveChangesAsync();
            return mapper.Map<UserDTO>(User);
        }
    }
}
