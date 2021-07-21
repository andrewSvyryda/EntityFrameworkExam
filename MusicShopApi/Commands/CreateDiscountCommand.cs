using MediatR;
using System;

namespace MusicShopApi.Commands
{
    public class CreateDiscountCommand : IRequest<DiscountDTO>
    {
        public string Name { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int DiscountValue { get; set; }
    }
}
