using MediatR;

namespace MusicShopApi.Commands
{
    public class CreatePublisherCommand : IRequest<PublisherDTO>
    {
        public string Name { get; set; }
    }
}
