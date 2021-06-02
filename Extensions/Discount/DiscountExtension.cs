using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionObjects.Extensions
{
    interface DiscountExtension : Extension
    {
        double modifyTotalPrice(double price);
    }
}
