using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProductInventoryTracker
{
    /// <summary>
    /// Interaction logic for ProductManagementWindow.xaml
    /// </summary>
    public partial class ProductManagementWindow : Window
    {
        private InventoryManager inventoryManager;

        public ProductManagementWindow(InventoryManager manager)
        {
            InitializeComponent();
            this.inventoryManager = manager;

            // 1. Tells the Window where to look for data
            this.DataContext = this.inventoryManager;

            // 2. Tells Manager to get the cars from SQL DB
            this.inventoryManager.GetAllProducts();
        }

        // Add button
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow pw = new AddProductWindow(this.inventoryManager);

            pw.ShowDialog();
        }

        // Edit button
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            // 1. Grabs the product currently selected in the DataGrid.
            var selectedProduct = dgProducts.SelectedItem as Product;

            if (selectedProduct != null)
            {
                // 2. Passes the manager and the selected product to the window.
                EditProductWindow pw = new EditProductWindow(this.inventoryManager, selectedProduct);

                pw.ShowDialog();
            }
            else
            {
                // Message box if user clicks the Edit button without selecting an item on the list.
                MessageBox.Show("Please select a product to edit first.");
            }
        }

        // Delete button
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // 1. Select product from DataGrid.
            var selectedProduct = dgProducts.SelectedItem as Product;

            if (selectedProduct != null)
            {
                // 2. Ask for user-confirmation first.
                var result = MessageBox.Show($"Delete {selectedProduct.Name} permanently?", "Confirm", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    // 3. Call the Manager
                    this.inventoryManager.DeleteProduct(selectedProduct);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.");
            }
        }

        private void btnQuickAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = (Product)this.dgProducts.SelectedItem;

                product.Quantity += 1;

                this.inventoryManager.UpdateProduct(product);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a product to quick add to its quantity.");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Max product quantity limit reached.");
            }
        }

        private void btnQuickDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = (Product)this.dgProducts.SelectedItem;

                product.Quantity -= 1;

                this.inventoryManager.UpdateProduct(product);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a product to quick delete to its quantity.");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Cannot have less than 1 quantity of a product.");
            }
        }
    }
}
