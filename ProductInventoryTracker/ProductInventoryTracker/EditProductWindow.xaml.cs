using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProductInventoryTracker
{
    /// <summary>
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        private InventoryManager manager;
        private Product selectedProduct;

        public EditProductWindow(InventoryManager manager, Product selected)
        {
            // Constructor Injection (requires these two parameters or the window won't open)
            InitializeComponent();
            this.manager = manager;
            this.selectedProduct = selected;

            // TextBox names from EditProduct xaml file
            txtName.Text = selectedProduct.Name;
            txtPrice.Text = selectedProduct.Price.ToString();
            txtQty.Text = selectedProduct.Quantity.ToString();
            txtTotal.Text = selectedProduct.Subtotal.ToString();
        }

        // Save button
        private void btnSaveProd_Click(object sender, RoutedEventArgs e)
        {
            // Syncs new data that the user just edited.
            selectedProduct.Name = txtName.Text;
            selectedProduct.Price = decimal.Parse(txtPrice.Text);
            selectedProduct.Quantity = int.Parse(txtQty.Text);

            manager.UpdateProduct(selectedProduct);
            MessageBox.Show($"{selectedProduct.Name} was successfully updated in the database!");
            this.Close();
        }
    }
}
