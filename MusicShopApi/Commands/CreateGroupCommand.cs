using MediatR;

namespace MusicShopApi.Commands
{
    public class CreateGroupCommand : IRequest<GroupDTO>
    {
        public string Name { get; set; }
    }
}
