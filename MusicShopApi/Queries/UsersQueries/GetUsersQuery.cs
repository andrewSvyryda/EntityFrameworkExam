using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetUsersQuery : IRequest<List<UserDTO>>
    {
    }
}
