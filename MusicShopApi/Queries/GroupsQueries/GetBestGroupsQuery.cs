using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetBestGroupsQuery : IRequest<List<GroupDTO>>
    {
        public int Count { get; }
        public GetBestGroupsQuery(int count)
        {
            Count = count;
        }
    }
}
