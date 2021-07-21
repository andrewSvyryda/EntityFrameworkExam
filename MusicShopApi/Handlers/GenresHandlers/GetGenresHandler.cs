using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetGenresHandler : IRequestHandler<GetGenresQuery, List<GenreDTO>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetGenresHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<GenreDTO>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
        {
            await context.Genres.LoadAsync();
            return mapper.Map<List<GenreDTO>>(context.Genres);
        }
    }
}
