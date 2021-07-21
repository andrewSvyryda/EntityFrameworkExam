using MediatR;
using MusicShopApi.Commands;
using MusicShopApi.Queries;
using System.Threading.Tasks;

namespace MusicShopApi.Services
{
    public interface IChangeUserService
    {
        public Task<int> ChangeUser(ChangeUserCommand command);
    }
    public class ChangeUserService : IChangeUserService
    {
        private readonly IMediator mediator;

        public ChangeUserService(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<int> ChangeUser(ChangeUserCommand command)
        {
            UserDTO user = await mediator.Send(new LoginQuery(command.Login, command.OldPassword));
            if (user.Id < 0)
                return user.Id;
            command.Id = user.Id;
            return await mediator.Send(command);
        }
    }
}
