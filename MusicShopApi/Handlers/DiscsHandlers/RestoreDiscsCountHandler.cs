using AutoMapper;
using MediatR;
using MusicShopApi.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers.GenresHandlers
{
    public class RestoreDiscsCountHandler : IRequestHandler<RestoreDiscsCountCommand, int>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public RestoreDiscsCountHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<int> Handle(RestoreDiscsCountCommand request, CancellationToken cancellationToken)
        {
            request.Disc.Count += request.Count;
            if (request.Disc.Count < 0)
                request.Disc.Count = 0;
            await context.SaveChangesAsync();
            return request.Disc.Count;
        }
    }


    
}
