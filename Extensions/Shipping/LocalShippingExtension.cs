using ExtensionObjects.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionObjects.Extensions
{
    public class LocalShippingExtension : ShippingExtension
    {
        public double modifyTotalPrice(double price)
        {
            return price + 2.5;
        }

        public int SetUpShippingTime(int importance)
        {
            int shippingDays;
            if (importance == 1)
            {
                return 1;
            }
            else
            {
                shippingDays = 2 * importance;
            }
            return shippingDays;
        }
    }
}
