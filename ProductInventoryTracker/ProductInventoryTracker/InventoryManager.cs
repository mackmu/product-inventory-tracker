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

        /// <summary>
        /// Create and add a product.
        /// </summary>
        public void AddProduct(string name, decimal price, int qty, int catId, int supId)
        {
            // 1. Send it to SQL
            inventoryService.AddProduct(name, price, qty, catId, supId);

            Product newP = new Product(0, name, price, qty, catId, supId);

            // Add to list
            this.ProductList.Add(newP);
        }

        // Load database products from InventoryService.
        public void GetAllProducts()
        {
            // 1. Clears the current list
            this.ProductList.Clear();

            // 2. Fetch the latest data from SQL Service
            List<Product> databaseProducts = inventoryService.GetProducts();

            // 3. Pour the database results into the ObservableCollection
            foreach (var p in databaseProducts)
            {
                this.ProductList.Add(p);
            }
        }

        public override string ToString()
        {
            return $"{ProductList.Count} Products and {SupplierList.Count} Suppliers";
        }
    }
}
