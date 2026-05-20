using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;


namespace ProductInventoryTracker
{
    public class InventoryManager
    {
        private InventoryService inventoryService;

        public ObservableCollection<Product> ProductList {  get; set; }
        public ObservableCollection<Supplier> SupplierList { get; set; }
        public ObservableCollection<Category> CategoryList { get; set; }

        public InventoryManager()
        {
            ProductList = new ObservableCollection<Product>();
            SupplierList = new ObservableCollection<Supplier>();
            CategoryList = new ObservableCollection<Category>();
            inventoryService = new InventoryService();
        }

        public int TotalProductCount()
        {
            return this.inventoryService.GetTotalProductCount();
        }

        /// <summary>
        /// Create and add a product.
        /// </summary>
        public void AddProduct(string name, decimal price, int qty, int catId, int supId)
        {
            Product newP = new Product(0, name, price, qty, catId, supId);

            // 1. Send it to SQL
            inventoryService.AddProduct(name, price, qty, catId, supId);

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

        public void DeleteProduct(Product productToDelete)
        {
            // 1. Send deletion request from UI to InventoryService file which handles DB connection and CRUD functions.
            inventoryService.DeleteProduct(productToDelete.ProductID.ToString());

            // 2. Remove from the local ObservableCollection so the UI refreshes
            this.ProductList.Remove(productToDelete);
        }

        public override string ToString()
        {
            return $"{ProductList.Count} Products and {SupplierList.Count} Suppliers";
        }
        public void UpdateProduct(Product p)
        {
            // Call InventoryService to update SQL and update DB.
            inventoryService.UpdateProduct(
                p.ProductID,
                p.Name,
                p.Price,
                p.Quantity,
                p.CategoryID,
                p.SupplierID
            );

            // 2. Force refresh from the DB so the UI sees the new values
            this.GetAllProducts();
        }

        // List of categories
        public void LoadCategories()
        {
            // Clear old data for possible duplicates.
            this.CategoryList.Clear();

            var categories = inventoryService.GetCategories();

            // Move the items into your ObservableCollection bucket
            foreach (var cat in categories)
            {
                this.CategoryList.Add(cat);
            }
        }

        // List of categories
        public void LoadSuppliers()
        {
            // Clear old data for possible duplicates.
            this.SupplierList.Clear();

            var suppliers = inventoryService.GetSuppliers();

            // Move the items into the ObservableCollection bucket
            foreach (var sup in suppliers)
            {
                this.SupplierList.Add(sup);
            }
        }

        // Add Supplier to DB
        public void AddSupplier(string name, string email, string phone)
        {
            inventoryService.AddSupplier(name, email, phone);
        }

        public void UpdateSupplier(int id, string name, string email, string phone)
        {
            inventoryService.UpdateSupplier(id, name, email, phone);
            this.LoadSuppliers();
        }

        public void DeleteSupplier(Supplier supplierToDelete)
        {
            inventoryService.DeleteSupplier(supplierToDelete.SupplierID);
            this.SupplierList.Remove(supplierToDelete);
        }
    } 
}
