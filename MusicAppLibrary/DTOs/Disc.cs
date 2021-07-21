using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicAppLibrary
{
    public class DiscDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public int GenreId { get; set; }
        public GenreDTO Genre { get; set; }
        public int PublisherId { get; set; }
        public PublisherDTO Publisher { get; set; }
        //public virtual IEnumerable<TrackDTO> Tracks { get; set; }
        public int GroupId { get; set; }
        public GroupDTO Group { get; set; }
        //public virtual ICollection<SaleDTO> Sales { get; set; }
        public ICollection<int> DiscountsId { get; set; }
        public ICollection<DiscountDTO> Discounts { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

}