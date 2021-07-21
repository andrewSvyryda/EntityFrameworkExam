using MediatR;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MusicShopApi.Commands
{
    public class ChangeDiscCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? PublishDate { get; set; }
        public int? Price { get; set; }
        public int? Count { get; set; }
        public int? GenreId { get; set; }
        public int? GroupId { get; set; }
        public int? PublisherId { get; set; }
        public ICollection<int> DiscountsId { get; set; }
        [JsonIgnore]
        public ICollection<Discount> Discounts { get; set; }
    }
}
