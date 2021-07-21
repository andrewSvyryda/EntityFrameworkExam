using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Disc, DiscDTO>();
            CreateMap<DiscDTO, Disc>();
            CreateMap<Discount, DiscountDTO>();
            CreateMap<DiscountDTO, Discount>();
            CreateMap<Genre, GenreDTO>();
            CreateMap<GenreDTO, Genre>();
            CreateMap<Group, GroupDTO>();
            CreateMap<GroupDTO, Group>();
            CreateMap<Publisher, PublisherDTO>();
            CreateMap<PublisherDTO, Publisher>();
            CreateMap<Sale, SaleDTO>();
            CreateMap<SaleDTO, Sale>();
            CreateMap<Track, TrackDTO>().ForMember(t => t.DurationInSec, t => t.MapFrom(opt => opt.Duration.TotalSeconds));
            CreateMap<TrackDTO, Track>().ForMember(t => t.Duration, t => t.MapFrom(opt => TimeSpan.FromSeconds(opt.DurationInSec))); ;
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
