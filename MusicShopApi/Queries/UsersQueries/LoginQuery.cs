using MediatR;

namespace MusicShopApi.Queries
{
    public class LoginQuery : IRequest<UserDTO>
    {
        public LoginQuery(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; set; }
        public string Password { get; set; }
    }
}
