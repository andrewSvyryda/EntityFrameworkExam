using MediatR;

namespace MusicShopApi.Queries
{
    public class GetGroupByIdQuery : IRequest<GroupDTO>
    {
        public GetGroupByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
