using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;


namespace ProductInventoryTracker
{
    public class InventoryManager
    {
        private InventoryService inventoryService;

        public ObservableCollection<Product> ProductList {  get; set; }
        public ObservableCollection<Supplier> SupplierList { get; set; }

        public InventoryManager()
        {
            ProductList = new ObservableCollection<Product>();
            SupplierList = new ObservableCollection<Supplier>();
            inventoryService = new InventoryService();
        }

        public void AddProduct(Product product)
        {
        }

        public List<Product> GetAllProducts()
        {
            return inventoryService.GetProducts();
        }

        public override string ToString()
        {
            return $"{ProductList.Count} Products and {SupplierList.Count} Suppliers";
        }
    }
}
