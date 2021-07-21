using AutoMapper;
using MediatR;
using MusicShopApi.Commands;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers.GenresHandlers
{
    public class ChangeDiscHandler : IRequestHandler<ChangeDiscCommand, int>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public ChangeDiscHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<int> Handle(ChangeDiscCommand request, CancellationToken cancellationToken)
        {
            Disc Disc = context.Discs.Single(d => d.Id == request.Id);
            Disc.Name = request.Name;
            if (request.Count != null) Disc.Count = (int)request.Count;
            if (request.GenreId != null) Disc.GenreId = (int)request.GenreId;
            if (request.GroupId != null) Disc.GroupId = (int)request.GroupId;
            if (request.Price != null) Disc.Price = (int)request.Price;
            if (request.PublishDate != null) Disc.PublishDate = (DateTime)request.PublishDate;
            if (request.PublisherId != null) Disc.PublisherId = (int)request.PublisherId;
            if (request.Discounts != null) Disc.Discounts = request.Discounts;
            await context.SaveChangesAsync();
            return mapper.Map<int>(Disc.Id);
        }
    }

}
