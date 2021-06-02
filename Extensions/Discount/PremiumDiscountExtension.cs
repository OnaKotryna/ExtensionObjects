using ExtensionObjects.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionObjects.Extensions
{
    public class PremiumDiscountExtension : DiscountExtension
    {
        public double modifyTotalPrice(double price)
        {
            return price * 0.6;
        }

    }
}
