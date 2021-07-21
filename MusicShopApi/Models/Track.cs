using System;
using System.ComponentModel.DataAnnotations;

namespace MusicShopApi
{
    public class Track
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public int DiscId { get; set; }
        public virtual Disc Disc { get; set; }
    }

}