using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionObjects.Extensions
{
    interface ShippingExtension : Extension
    {
        double modifyTotalPrice(double price);
        int SetUpShippingTime(int importance);
    }
}
