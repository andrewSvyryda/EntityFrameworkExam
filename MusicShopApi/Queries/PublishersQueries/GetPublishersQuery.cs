using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetPublishersQuery : IRequest<List<PublisherDTO>>
    {
    }
}
