using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicShopApi.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicShopApi.Handlers
{
    public class GetBestGroupsHandler : IRequestHandler<GetBestGroupsQuery, List<GroupDTO>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetBestGroupsHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public static int GetCountByGroup(Group group)
        {
            int count = 0;
            foreach (var d in group.Discs)
            {
                count += d.Sales.Count;
            }
            return count;
        }
        public class Comparer : IComparer<Group>
        {
            public int Compare(Group x, Group y)
            {
                if (GetCountByGroup(x) > GetCountByGroup(y))
                    return -1;
                else if (GetCountByGroup(x) < GetCountByGroup(y))
                    return 1;
                return 0;
            }
        }
        public async Task<List<GroupDTO>> Handle(GetBestGroupsQuery request, CancellationToken cancellationToken)
        {
            await context.Groups.Include(g => g.Discs).LoadAsync();
            await context.Discs.Include(d => d.Group).Include(d => d.Sales).LoadAsync();
            List<Group> list = await context.Groups.ToListAsync();
            list.Sort(new Comparer());
            return mapper.Map<List<GroupDTO>>(list.Take(request.Count));

            //await context.Groups.OrderByDescending(g => g.Discs.Select(d => d.Sales.Count).Sum()).Take(request.Count).LoadAsync();
            //return mapper.Map<List<GroupDTO>>(context.Groups.OrderByDescending(g => g.Discs.Select(d => d.Sales.Count).Sum()).Take(request.Count));
            //await context.Groups.OrderByDescending(g => context.Sales.Where(s => s.Discs.Any(a => context.Discs.Where(d => d.GroupId == g.Id).Select(d => d.Id).Contains(a.Id))).Count()).Take(request.Count).LoadAsync();
            //return mapper.Map<List<GroupDTO>>(context.Groups.OrderByDescending(g => context.Sales.Where(s => s.Discs.Any(a => context.Discs.Where(d => d.GroupId == g.Id).Select(d => d.Id).Contains(a.Id))).Count()).Take(request.Count));
        }
    }


    public class GetBestGenresByTimeSectionHandler : IRequestHandler<GetBestGenresByTimeSectionQuery, List<GenreDTO>>
    {
        private readonly MusicalShopModel context;
        private readonly IMapper mapper;

        public GetBestGenresByTimeSectionHandler(MusicalShopModel context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public static int GetCountByGenre(Genre genre)
        {
            int count = 0;
            foreach (var d in genre.Discs)
            {
                count += d.Sales.Count;
            }
            return count;
        }
        public class Comparer : IComparer<Genre>
        {
            public int Compare(Genre x, Genre y)
            {
                if (GetCountByGenre(x) > GetCountByGenre(y))
                    return -1;
                else if (GetCountByGenre(x) < GetCountByGenre(y))
                    return 1;
                return 0;
            }
        }
        public async Task<List<GenreDTO>> Handle(GetBestGenresByTimeSectionQuery request, CancellationToken cancellationToken)
        {
            DateTime time = DateTime.Now.AddDays(-1 * (int)request.TimeSection);
            await context.Genres.Include(g => g.Discs).LoadAsync();
            await context.Discs.Include(d => d.Genre).Include(d => d.Sales.Where(s => s.SaleDate > time)).LoadAsync();
            List<Genre> list = await context.Genres.ToListAsync();
            list.Sort(new Comparer());
            return mapper.Map<List<GenreDTO>>(list.Take(request.Count));

            //await context.Groups.OrderByDescending(g => g.Discs.Select(d => d.Sales.Count).Sum()).Take(request.Count).LoadAsync();
            //return mapper.Map<List<GroupDTO>>(context.Groups.OrderByDescending(g => g.Discs.Select(d => d.Sales.Count).Sum()).Take(request.Count));
            //await context.Groups.OrderByDescending(g => context.Sales.Where(s => s.Discs.Any(a => context.Discs.Where(d => d.GroupId == g.Id).Select(d => d.Id).Contains(a.Id))).Count()).Take(request.Count).LoadAsync();
            //return mapper.Map<List<GroupDTO>>(context.Groups.OrderByDescending(g => context.Sales.Where(s => s.Discs.Any(a => context.Discs.Where(d => d.GroupId == g.Id).Select(d => d.Id).Contains(a.Id))).Count()).Take(request.Count));
        }
    }

    
}
