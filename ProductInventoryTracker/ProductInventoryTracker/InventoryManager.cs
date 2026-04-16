using System;
using System.Collections.Generic;
using System.Text;

namespace ProductInventoryTracker
{
    public class InventoryManager
    {
        public List<Product> ProductList {  get; set; }
        public List<Supplier> SupplierList { get; set; }

        public InventoryManager()
        {
            ProductList = new List<Product>();
            SupplierList = new List<Supplier>();
        }

    }
}
