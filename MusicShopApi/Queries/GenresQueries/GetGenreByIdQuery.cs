using MediatR;

namespace MusicShopApi.Queries
{
    public class GetGenreByIdQuery : IRequest<GenreDTO>
    {
        public GetGenreByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
