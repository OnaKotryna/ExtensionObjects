using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionObjects.Extensions
{
    public class InternationalShippingExtension : ShippingExtension
    {
        public double modifyTotalPrice(double price)
        {
            return price + 50;
        }

        public int SetUpShippingTime(int importance)
        {
            int shippingDays;
            if (importance == 1)
            {
                return 2;
            }
            else
            {
                shippingDays = 7 * importance;
            }
            return shippingDays;
        }
    }
}
