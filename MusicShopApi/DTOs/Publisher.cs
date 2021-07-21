using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicShopApi
{
    public class PublisherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<DiscDTO> Discs { get; set; }
    }

}