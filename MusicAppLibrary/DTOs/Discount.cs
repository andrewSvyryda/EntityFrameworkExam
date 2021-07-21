using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicAppLibrary
{
    public class DiscountDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DiscountValue { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }

}