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
    public partial class ProductWindow : Window
    {
        private InventoryManager manager;
        public ProductWindow(InventoryManager manager)
        {
            InitializeComponent();
            this.manager = manager;
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

            // 2. Create the object.
            Product myProduct = new Product(0, "Temp", d1, d2, 0);
            this.manager.ProductList.Add(myProduct);

            // 3. Get the Subtotal property from the Product class.
            lblSubtotalDisplay.Text = myProduct.Subtotal.ToString("C"); // (Show currency)
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
                // Instantiate a temporary Product.
                Product tempProduct = new Product(0, txtProductName.Text, decimal.Parse(txtPrice.Text), int.Parse(txtQuantity.Text), 0);

                // Add it to the Product list and show Success Message.
                this.manager.ProductList.Add(tempProduct);
                MessageBox.Show("Product saved successfully!");
                this.ResetProductForm();
            }
            catch (ArgumentOutOfRangeException ex)
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
