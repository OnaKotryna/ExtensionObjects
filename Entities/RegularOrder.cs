using ExtensionObjects.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionObjects.Entities
{
    class RegularOrder : IOrder
    {
        private double price;
        private int importance;
        private Dictionary<string, Extension> extensions = new Dictionary<string, Extension>();

        public RegularOrder(double price, int importance)
        {
            this.price = price;
            this.importance = importance;
        }

        public int GetImportance()
        {
            return importance;
        }

        public double GetPrice()
        {
            return price;
        }
        
        public double GetTotalPrice(double price)
        {
            
            double baseTotal = price + price * 0.21;
            foreach (KeyValuePair<string, Extension> ext in extensions)
            {
                baseTotal = ext.Value.modifyTotalPrice(baseTotal);
            }
            return baseTotal;
        }

        public void AddExtension(string roleName, Extension extension)
        {
            this.extensions.Add(roleName, extension);
        }

        public Extension GetExtension(string roleName)
        {
            Extension extention = null;
            foreach (KeyValuePair<string, Extension> ext in extensions)
            {
                if (ext.Key == roleName)
                {
                    extention = ext.Value;
                }
            }
            return extention;
        }

        public void RemoveExtension(string roleName)
        {
            extensions.Remove(roleName);
        }
    }
}
