using ExtensionObjects.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionObjects.Extensions
{
    public class PromoCodeDiscountExtension : DiscountExtension
    {
        public double modifyTotalPrice(double price)
        {
            return price * 0.8;
        }

    }
}
