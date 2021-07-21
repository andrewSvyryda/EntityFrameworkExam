using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopApi.Queries
{
    public class GetDiscsQuery : IRequest<List<DiscDTO>>
    {
    }
}
