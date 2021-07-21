using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicAppLibrary
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual IEnumerable<DiscDTO> Discs { get; set; }
    }

}