using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MusicAppLibrary
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public bool IsAdmin { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public int CurrentDiscount { get; set; }
        [JsonIgnore]
        public virtual ICollection<SaleDTO> Sales { get; set; }
    }

}