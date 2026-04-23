using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace ProductInventoryTracker
{
    public class InventoryManager
    {
        public ObservableCollection<Product> ProductList {  get; set; }
        public ObservableCollection<Supplier> SupplierList { get; set; }

        public InventoryManager()
        {
            ProductList = new ObservableCollection<Product>();
            SupplierList = new ObservableCollection<Supplier>();
        }

        public override string ToString()
        {
            return $"{ProductList.Count} Products and {SupplierList.Count} Suppliers";
        }

    }
}
