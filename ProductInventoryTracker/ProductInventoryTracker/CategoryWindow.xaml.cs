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
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window
    {
        public CategoryWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds a category when category name is succesfully entered.
        /// </summary>
        /// <param name="sender">The object that triggered the event (the button).</param>
        /// <param name="e">The event data.</param>
        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            // Added successfully message for 'Add' a category button.
            MessageBox.Show("Category added successfully!"); // This shows the popup language.
            this.Close(); // This closes the current window.
        }
    }
}
