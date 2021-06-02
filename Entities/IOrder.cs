using ExtensionObjects.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionObjects.Entities
{
    public interface IOrder
    {
        public double GetTotalPrice(double price);
        public void AddExtension(string roleName, Extension extension);
        public Extension GetExtension(string roleName);
        public void RemoveExtension(string roleName);
    }
}
