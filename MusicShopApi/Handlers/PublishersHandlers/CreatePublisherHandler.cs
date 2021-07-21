using AutoMapper;
using MediatR;
using MusicShopApi.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers.GenresHandlers
{
    public class CreatePublisherHandler : IRequestHandler<CreatePublisherCommand, PublisherDTO>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public CreatePublisherHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<PublisherDTO> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
        {
            Publisher Publisher = (await context.Publishers.AddAsync(new Publisher { Name = request.Name })).Entity;
            await context.SaveChangesAsync();
            return mapper.Map<PublisherDTO>(Publisher);
        }
    }
}
