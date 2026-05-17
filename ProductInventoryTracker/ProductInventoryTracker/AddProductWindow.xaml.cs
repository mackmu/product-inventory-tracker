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
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private InventoryManager manager;
        public AddProductWindow(InventoryManager manager)
        {
            InitializeComponent();
            this.manager = manager;

            // 1. Load Categories and Suppliers in the window
            this.manager.LoadCategories();
            this.manager.LoadSuppliers();

            // Supplier list dropdown selection data
            cmbSupplier.ItemsSource = this.manager.SupplierList;

            // Category list dropdown selection data
            cmbCategory.ItemsSource = this.manager.CategoryList;
        }

        /// <summary>
        /// Calculates and displays the product subtotal based on the entered price and quantity.
        /// </summary>
        /// <param name="sender">The object that triggered the event (the button).</param>
        /// <param name="e">The event data.</param>
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            // 1. Get numbers from the UI.
            decimal.TryParse(txtPrice.Text, out decimal d1);
            int.TryParse(txtQuantity.Text, out int d2);

            // 3. Get the Subtotal property from the Product class.
            lblSubtotalDisplay.Text = (d1 * d2).ToString("C"); // (Show currency)
        }

        /// <summary>
        /// Saves a product when product info is succesfully entered.
        /// </summary>
        /// <param name="sender">The object that triggered the event (the button).</param>
        /// <param name="e">The event data.</param>
        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Assign hidden database primary keys from the category and supplier dropdown menus.
                int selectedCategory = (int)cmbCategory.SelectedValue;
                int selectedSupplier = (int)cmbSupplier.SelectedValue;

                // Instantiate a Product (uses placeholder CategoryID and SupplierID)
                this.manager.AddProduct(txtProductName.Text, decimal.Parse(txtPrice.Text), int.Parse(txtQuantity.Text), selectedCategory, selectedSupplier);

                // Add it to the Product list and show Success Message.
                MessageBox.Show("Product saved successfully!");
                this.ResetProductForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Resets the Product window form fields.
        /// </summary>
        private void ResetProductForm()
        {
            // Clear name, email and phone.
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";

            //Reset the cursor to the name field.
            txtProductName.Focus();
        }
    }
}
