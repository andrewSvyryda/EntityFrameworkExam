using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicShopApi
{
    public class Discount
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int DiscountValue { get; set; }
        public virtual ICollection<Disc> Discs { get; set; }
    }

}