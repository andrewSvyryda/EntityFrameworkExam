using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopApi.Commands
{
    public class CreateGenreCommand : IRequest<GenreDTO>
    {
        public string Name { get; set; }
    }
    
    /*
    public class CreateGenreCommand : IRequest<GenreDTO>
    {
        public string GenreName { get; set; }
    }*/
}
