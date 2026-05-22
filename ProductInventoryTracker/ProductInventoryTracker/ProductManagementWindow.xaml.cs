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

        /// <summary>
        /// Data management service engine utilized to execute CRUD operations and 
        /// handle local inventory memory tracking states. 
        /// </summary>
        private InventoryManager inventoryManager;


        /// <summary>
        /// Initializes a new instance of the <see cref="ProductManagementWindow"/> class, 
        /// configures visual data binding contexts, and hydrates initial product datasets. 
        /// </summary>
        /// <param name="manager">The active inventory management service runtime dependency.</param>
        public ProductManagementWindow(InventoryManager manager)
        {
            InitializeComponent();
            this.inventoryManager = manager;

            // 1. Tells the Window where to look for data
            this.DataContext = this.inventoryManager;

            // 2. Tells Manager to get the cars from SQL DB
            this.inventoryManager.GetAllProducts();

        }

        /// <summary>
        /// Initializes and displays a modal dialog window for creating and adding 
        /// a new product record to the managed inventory system. 
        /// </summary>
        /// <param name="sender">The source of the click event.</param>
        /// <param name="e">The event data containing routing information.</param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow pw = new AddProductWindow(this.inventoryManager);

            pw.ShowDialog();

        }

        /// <summary>
        /// Retrieves the currently selected product from the data grid and opens an 
        /// interactive dialog window to modify its inventory properties. 
        /// </summary>
        /// <param name="sender">The source of the click event.</param>
        /// <param name="e">The event data containing routing information.</param>
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

        /// <summary>
        /// Permanently deletes the selected product from the inventory database
        /// after requesting explicit verification from the user via a confirmation dialog. 
        /// </summary>
        /// <param name="sender">The source of the click event.</param>
        /// <param name="e">The event data containing routing information.</param>
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

        /// <summary>
        /// Increments the inventory quantity of the selected product by one, 
        /// updates the persistent data storage, and refreshes the user interface grid. 
        /// </summary>
        /// <param name="sender">The source of the click event.</param>
        /// <param name="e">The event data containing routing information.</param>
        private void btnQuickAdd_Click(object sender, RoutedEventArgs e)
        {
            // Unselected state message
            if (dgProducts.SelectedItem == null || dgProducts.SelectedItem == CollectionView.NewItemPlaceholder)
            {
                MessageBox.Show("Please select a product from the list first.", "No Item Selected");
                return;
            }

            try
            {
                var product = dgProducts.SelectedItem as Product;
                if (product != null)
                {
                    int selectedIndex = dgProducts.SelectedIndex;

                    product.Quantity += 1;
                    this.inventoryManager.UpdateProduct(product);

                    // Reset UI state
                    this.dgProducts.Items.Refresh();
                    dgProducts.SelectedIndex = selectedIndex;
                    dgProducts.Focus(); // Force focus for rapid clicks
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Max product quantity limit reached (100,000).", "Limit Reached");
            }

        }

        /// <summary>
        /// Decrements the inventory quantity of the selected product by one, 
        /// validates lower inventory boundaries, updates storage, and refreshes the UI grid. 
        /// </summary>
        /// <param name="sender">The source of the click event.</param>
        /// <param name="e">The event data containing routing information.</param>
        private void btnQuickDelete_Click(object sender, RoutedEventArgs e)
        {
            // Unselected state message
            if (dgProducts.SelectedItem == null || dgProducts.SelectedItem == CollectionView.NewItemPlaceholder)
            {
                MessageBox.Show("Please select a product from the list first.", "No Item Selected");
                return;
            }

            try
            {
                var product = dgProducts.SelectedItem as Product;
                if (product != null)
                {
                    if (product.Quantity <= 0)
                    {
                        MessageBox.Show("Cannot have less than 0 quantity of a product.", "Inventory Boundary");
                        return;
                    }

                    int selectedIndex = dgProducts.SelectedIndex;

                    product.Quantity -= 1;
                    this.inventoryManager.UpdateProduct(product);

                    this.dgProducts.Items.Refresh();
                    dgProducts.SelectedIndex = selectedIndex;
                    dgProducts.Focus(); // Force focus for rapid clicks
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Cannot lower quantity further.", "Error");
            }

        }
    }
}
