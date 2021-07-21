using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetDiscsByGroupQuery : IRequest<List<DiscDTO>>
    {
        public int GroupId { get; }
        public GetDiscsByGroupQuery(int id)
        {
            GroupId = id;
        }
    }
}
