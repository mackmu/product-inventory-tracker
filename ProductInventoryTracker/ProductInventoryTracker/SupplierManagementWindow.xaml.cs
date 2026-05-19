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
    /// Interaction logic for SupplierManagementWindow.xaml
    /// </summary>
    public partial class SupplierManagementWindow : Window
    {

        private InventoryManager manager;

        public SupplierManagementWindow(InventoryManager manager)
        {
            InitializeComponent();
            this.manager = manager;

            // Load suppliers from the DB.
            this.manager.LoadSuppliers();

            // 2. Connect supplier list to grid.
            dgSuppliers.ItemsSource = this.manager.SupplierList;
        }

        private void btnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            AddSupplierWindow addWindow = new AddSupplierWindow(this.manager);

            // 2. Open a modal dialog box
            bool? result = addWindow.ShowDialog();

            // 3. Refresh the dashboard grid once it closes to see changes immediately.
            this.manager.LoadSuppliers();
        }

        private void btnEditSupplier_Click(object sender, RoutedEventArgs e)
        {
            // Select supplier in the DataGrid.
            var selectedSupplier = dgSuppliers.SelectedItem as Supplier;

            if (selectedSupplier != null)
            {
                // 2. Pass the manager and selected supplier to overloaded window constructor.
                AddSupplierWindow sw = new AddSupplierWindow(this.manager, selectedSupplier);
                sw.ShowDialog();

                // 3. Refresh the grid layout from the database after it closes.
                this.manager.LoadSuppliers();
            }
            else
            {
                MessageBox.Show("Please select a supplier to edit first.");
            }
        }

        private void btnDeleteSupplier_Click(object sender, RoutedEventArgs e)
        {
            // Select supplier to be deleted.
            var selectedSupplier = dgSuppliers.SelectedItem as Supplier;

            if (selectedSupplier != null)
            {
                // Confirm deletion message.
                var result = MessageBox.Show($"Delete {selectedSupplier.SupplierName} permanently?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    this.manager.DeleteSupplier(selectedSupplier);
                }
            }
            else
            {
                MessageBox.Show("Please select a supplier from the list to delete.");
            }
        }
    }
}
