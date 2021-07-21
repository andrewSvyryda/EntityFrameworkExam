using MediatR;
using System.Collections.Generic;

namespace MusicShopApi.Queries
{
    public class GetBestGenresByTimeSectionQuery : IRequest<List<GenreDTO>>
    {
        public GetBestGenresByTimeSectionQuery(TimeSection timeSection, int count)
        {
            TimeSection = timeSection;
            Count = count;
        }

        public TimeSection TimeSection { get; set; }
        public int Count { get; set; }
    }
}
