using AutoMapper;
using MediatR;
using MusicShopApi.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers.GenresHandlers
{
    public class CreateGroupHandler : IRequestHandler<CreateGroupCommand, GroupDTO>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public CreateGroupHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<GroupDTO> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            Group Group = (await context.Groups.AddAsync(new Group { Name = request.Name })).Entity;
            await context.SaveChangesAsync();
            return mapper.Map<GroupDTO>(Group);
        }
    }
}
