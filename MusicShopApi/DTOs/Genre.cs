using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicShopApi
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual IEnumerable<DiscDTO> Discs { get; set; }
    }

}