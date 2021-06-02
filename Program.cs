using ExtensionObjects.Entities;
using ExtensionObjects.Extensions;
using System;

namespace ExtensionObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Esybės:");
            RegularOrder regularOrder = new RegularOrder(20, 1);
            PreOrder preOrder = new PreOrder(20, 2);
            Console.WriteLine("  Regular order kaina (su PVM): " + regularOrder.GetTotalPrice(regularOrder.GetPrice()));
            Console.WriteLine("  PreOrder kaina (-30 %): " + preOrder.GetTotalPrice(preOrder.GetPrice()));


            Console.WriteLine("Praplėstos esybės:");

            Console.WriteLine(" -Premium discount (-40 %):");
            regularOrder.AddExtension("premiumDiscount", new PremiumDiscountExtension());
            preOrder.AddExtension("premiumDiscount", new PremiumDiscountExtension());
            
            Console.WriteLine("    Regular Order: " + regularOrder.GetTotalPrice(regularOrder.GetPrice()));
            Console.WriteLine("    PreOrder: " + preOrder.GetTotalPrice(preOrder.GetPrice())) ;

            regularOrder.RemoveExtension("premiumDiscount");
            preOrder.RemoveExtension("premiumDiscount");

            Console.WriteLine(" -PromoCode discount (-20 %):");

            regularOrder.AddExtension("promoDiscount", new PromoCodeDiscountExtension());
            preOrder.AddExtension("promoDiscount", new PromoCodeDiscountExtension());

            Console.WriteLine("    Regular Order: " + regularOrder.GetTotalPrice(regularOrder.GetPrice()));
            Console.WriteLine("    PreOrder: " + String.Format("{0:0.00}", preOrder.GetTotalPrice(preOrder.GetPrice())));

            regularOrder.RemoveExtension("promoDiscount");
            preOrder.RemoveExtension("promoDiscount");

            Console.WriteLine(" -PreOrder with Local shipping + PromoCode Discount (-20 %):");
            preOrder.AddExtension("promoDiscount", new PromoCodeDiscountExtension());
            preOrder.AddExtension("localShipping", new LocalShippingExtension());
            Console.WriteLine("    Price: " + String.Format("{0:0.00}", preOrder.GetTotalPrice(preOrder.GetPrice())));

            Console.WriteLine(" -RegularOrder with International Shipping + Premium Discount (-40 %) + PromoCode Discount (-20 %):");
            regularOrder.AddExtension("promoDiscount", new PromoCodeDiscountExtension());
            regularOrder.AddExtension("premiumDiscount", new PremiumDiscountExtension());
            regularOrder.AddExtension("internationalShipping", new InternationalShippingExtension());
            Console.WriteLine("    Price: " + String.Format("{0:0.00}", regularOrder.GetTotalPrice(preOrder.GetPrice())));

            Console.WriteLine("Paieškos galimybė.\n Regular Order (price - 10) with PromoCode discount + Premium Discount + Local Shipping");
            RegularOrder entity = new RegularOrder(10, 1);
            entity.AddExtension("localShipping", new LocalShippingExtension());
            entity.AddExtension("premiumDiscount", new PremiumDiscountExtension());
            entity.AddExtension("promoDiscount", new PromoCodeDiscountExtension());
            Console.WriteLine("    Price: " + String.Format("{0:0.00}", entity.GetTotalPrice(entity.GetPrice())));

            Console.WriteLine(" Is there International shipping?");
            InternationalShippingExtension internationalShipping = (InternationalShippingExtension)entity.GetExtension("internationalShipping");
            if (internationalShipping != null)
            {
                Console.WriteLine("  Yes");
                int days = internationalShipping.SetUpShippingTime(entity.GetImportance());
                Console.WriteLine("  Added shipping days: " + days);
            }
            else
            {
                Console.WriteLine("  No");
            }
            Console.WriteLine(" Is there Local shipping?");
            LocalShippingExtension localShipping = (LocalShippingExtension)entity.GetExtension("localShipping");
            if (localShipping != null)
            {
                Console.WriteLine("  Yes");
                int days = localShipping.SetUpShippingTime(entity.GetImportance());
                Console.WriteLine("  Added shipping days: " + days);
            }
            else
            {
                Console.WriteLine("  No");
            }

        }
    }
}
