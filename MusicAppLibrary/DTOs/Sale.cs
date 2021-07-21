using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MusicAppLibrary
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public DateTime SaleDate { get; set; }
        [JsonIgnore]
        public virtual ICollection<DiscDTO> Discs { get; set; }
        public virtual ICollection<int> DiscsId { get; set; }
    }

}