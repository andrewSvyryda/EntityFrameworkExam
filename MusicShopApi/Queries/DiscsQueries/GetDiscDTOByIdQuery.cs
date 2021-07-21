using MediatR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopApi
{
    public class GetDiscDTOByIdQuery : IRequest<DiscDTO>
    {
        public GetDiscDTOByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
    public class GetDiscByIdQuery : IRequest<Disc>
    {
        public GetDiscByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
