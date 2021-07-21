using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetGroupsQuery : IRequest<List<GroupDTO>>
    {
    }
}
