using MediatR;

namespace MusicShopApi.Queries
{
    public class GetDiscountByIdQuery : IRequest<DiscountDTO>
    {
        public GetDiscountByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
