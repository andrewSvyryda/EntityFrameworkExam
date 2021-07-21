using MediatR;

namespace MusicShopApi.Commands
{
    public class CreateUserCommand : IRequest<UserDTO>
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
