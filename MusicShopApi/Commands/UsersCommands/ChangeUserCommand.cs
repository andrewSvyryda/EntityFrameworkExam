using MediatR;

namespace MusicShopApi.Commands
{
    public class ChangeUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public bool? IsAdmin { get; set; }
        public int? CurrentDiscount { get; set; }
    }
}
