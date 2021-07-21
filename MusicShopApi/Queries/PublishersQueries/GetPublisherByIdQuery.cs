using MediatR;

namespace MusicShopApi.Queries
{
    public class GetPublisherByIdQuery : IRequest<PublisherDTO>
    {
        public GetPublisherByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
