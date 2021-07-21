using System;
using System.Collections.Generic;

namespace MusicShopApi
{
    public class Sale
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Disc> Discs { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        
    }

}