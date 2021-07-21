﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicShopApi
{
    public class Group
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public virtual IEnumerable<Disc> Discs { get; set; }
    }

}