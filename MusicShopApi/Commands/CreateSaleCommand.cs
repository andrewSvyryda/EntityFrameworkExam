using MediatR;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MusicShopApi.Commands
{
    public class CreateSaleCommand : IRequest<SaleDTO>
    {
        public int UserId { get; set; }
        public int Price { get; set; }
        public DateTime SaleDate { get; set; }
        public ICollection<int> DiscsId { get; set; }
        [JsonIgnore]
        public ICollection<Disc> Discs { get; set; }
    }
}
