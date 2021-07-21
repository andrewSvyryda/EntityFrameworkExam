using AutoMapper;
using MediatR;
using MusicShopApi.Commands;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers.GenresHandlers
{
    public class ChangeUserHandler : IRequestHandler<ChangeUserCommand, int>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public ChangeUserHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<int> Handle(ChangeUserCommand request, CancellationToken cancellationToken)
        {
            User User = context.Users.Single(d => d.Id == request.Id);
            if (request.CurrentDiscount != null) User.CurrentDiscount = (int)request.CurrentDiscount;
            if (request.IsAdmin != null) User.IsAdmin = (bool)request.IsAdmin;
            if (request.Name != null) User.Name = request.Name;
            if (request.Password != null) User.Password = request.Password;
            await context.SaveChangesAsync();
            return mapper.Map<int>(User.Id);
        }
    }

}
