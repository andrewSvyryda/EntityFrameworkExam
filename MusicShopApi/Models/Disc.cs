using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicShopApi
{
    public class Disc
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual IEnumerable<Track> Tracks { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
    }
}