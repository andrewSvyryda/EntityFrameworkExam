using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicShopApi
{
    public class TrackDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public TimeSpan Duration { get; set; }
        public int DurationInSec { get; set; }
        public int DiscId { get; set; }
        public virtual DiscDTO Disc { get; set; }
    }

}