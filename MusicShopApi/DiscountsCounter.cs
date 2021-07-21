using System;
using System.Collections.Generic;

namespace MusicShopApi
{
    public static class DiscountsCounter
    {
        public static float GetComplextDiscountByDiscountsList(List<DiscountDTO> list)
        {
            float discountVal = 0;
            foreach (DiscountDTO discount in list)
            {
                if(discount.DiscountValue != 0 && discount.DateFrom < DateTime.Now && discount.DateTo > DateTime.Now)
                    discountVal += (100 - discountVal) * ((float)discount.DiscountValue / 100);
            }
            return 1 - discountVal / 100;
        }
    }

}
