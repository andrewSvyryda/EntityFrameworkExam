using AutoMapper;
using MediatR;
using MusicShopApi.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers.GenresHandlers
{
    public class CreateDiscHandler : IRequestHandler<CreateDiscCommand, int>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public CreateDiscHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<int> Handle(CreateDiscCommand request, CancellationToken cancellationToken)
        {
            Disc Disc = (await context.Discs.AddAsync(new Disc { Name = request.Name, Count = request.Count, GenreId = request.GenreId, GroupId = request.GroupId, Price = request.Price, Discounts = request.Discounts, PublishDate = request.PublishDate, PublisherId = request.PublisherId })).Entity;
            await context.SaveChangesAsync();
            return mapper.Map<int>(Disc.Id);
        }
    }


}
