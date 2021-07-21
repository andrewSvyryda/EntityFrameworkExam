using AutoMapper;
using MediatR;
using MusicShopApi.Commands;
using System.Threading.Tasks;

namespace MusicShopApi.Services
{

    public interface IRestoreDiscsCountService
    {
        public Task<int> RestoreDiscs(RestoreDiscsCountCommand command);
    }
    public class RestoreDiscsCountService : IRestoreDiscsCountService
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public RestoreDiscsCountService(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        public async Task<int> RestoreDiscs(RestoreDiscsCountCommand command)
        {

            command.Disc = await mediator.Send(new GetDiscByIdQuery(command.DiscId));
            int res = await mediator.Send(command);
            return res;
        }
    }
}
