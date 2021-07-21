using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicShopApi
{
    public class User
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Login { get; set; }
        [Required, MaxLength(100), MinLength(8)]
        public bool IsAdmin { get; set; } = false;
        public string Password { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public int? CurrentDiscount { get; set; }
    }

}