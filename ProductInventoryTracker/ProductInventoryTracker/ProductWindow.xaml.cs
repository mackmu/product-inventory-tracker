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
        public ProductWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Calculates and displays the product subtotal based on the entered price and quantity.
        /// </summary>
        /// <param name="sender">The object that triggered the event (the button).</param>
        /// <param name="e">The event data.</param>
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string s1 = txtPrice.Text;
            string s2 = txtQuantity.Text;

            decimal d1 = 0m;
            decimal.TryParse(s1, out d1);

            decimal d2 = 0m;
            decimal.TryParse(s2, out d2);

            decimal subtotal = (d1 * d2);

            lblSubtotalDisplay.Text = subtotal.ToString();
        }
    }
}
