using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetGenreByIdHandler : IRequestHandler<GetGenreByIdQuery, GenreDTO>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetGenreByIdHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<GenreDTO> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            await context.Genres.Where(g => g.Id == request.Id).LoadAsync();
            return mapper.Map<GenreDTO>(context.Genres.SingleOrDefault(g => g.Id == request.Id));
        }
    }
}
