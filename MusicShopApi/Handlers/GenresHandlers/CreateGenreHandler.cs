using AutoMapper;
using MediatR;
using MusicShopApi.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers.GenresHandlers
{
    public class CreateGenreHandler : IRequestHandler<CreateGenreCommand, GenreDTO>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public CreateGenreHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<GenreDTO> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            Genre genre = (await context.Genres.AddAsync(new Genre { Name = request.Name })).Entity;
            await context.SaveChangesAsync();
            return mapper.Map<GenreDTO>(genre);
        }
    }
}
