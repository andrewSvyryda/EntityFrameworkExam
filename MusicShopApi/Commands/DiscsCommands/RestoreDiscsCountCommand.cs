using MediatR;
using System.Text.Json.Serialization;

namespace MusicShopApi.Commands
{
    public class RestoreDiscsCountCommand : IRequest<int>
    {
        public int DiscId { get; set; }
        public int Count { get; set; }
        [JsonIgnore]
        public Disc Disc { get; set; }
    }
}
