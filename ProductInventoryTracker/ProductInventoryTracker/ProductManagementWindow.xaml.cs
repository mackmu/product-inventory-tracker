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
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow pw = new AddProductWindow(this.inventoryManager);

            pw.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
