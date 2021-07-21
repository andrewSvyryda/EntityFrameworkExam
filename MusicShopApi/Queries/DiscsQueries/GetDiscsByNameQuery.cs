using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetDiscsByNameQuery : IRequest<List<DiscDTO>>
    {
        public string DiscName { get; }
        public GetDiscsByNameQuery(string name)
        {
            DiscName = name;
        }
    }
}
