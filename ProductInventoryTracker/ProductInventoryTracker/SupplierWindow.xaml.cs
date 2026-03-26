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
    /// Interaction logic for SupplierWindow.xaml
    /// </summary>
    public partial class SupplierWindow : Window
    {
        public SupplierWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Saves a supplier when supplier info is succesfully entered.
        /// </summary>
        /// <param name="sender">The object that triggered the event (the button).</param>
        /// <param name="e">The event data.</param>
        private void btnSaveSupplier_Click(object sender, RoutedEventArgs e)
        {
            // Temporary Supplier object.
            Supplier tempSupplier = new Supplier(0, txtSupplierName.Text, txtSupplierEmail.Text);

            if (tempSupplier.IsNameValid == true)
            {
                // Success Message
                MessageBox.Show("Supplier saved successfully!");
                this.Close();
            }
            else
            {
                // Failure Message
                MessageBox.Show("Error: Supplier Name cannot be blank.");
            }
        }
    }
}
