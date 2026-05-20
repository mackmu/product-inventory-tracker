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
    /// Interaction logic for CategoryManagementWindow.xaml
    /// </summary>
    public partial class CategoryManagementWindow : Window
    {
        private InventoryManager manager;

        public CategoryManagementWindow(InventoryManager manager)
        {
            InitializeComponent();
            this.manager = manager;
            this.DataContext = this.manager;

            // Load records from the database
            this.manager.LoadCategories();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Open entry form
            CategoryWindow cw = new CategoryWindow(this.manager);
            cw.ShowDialog();
            this.manager.LoadCategories();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedCategory = dgCategories.SelectedItem as Category;

            if (selectedCategory != null)
            {
                // Open entry form via overloaded constructor
                CategoryWindow cw = new CategoryWindow(this.manager, selectedCategory);
                cw.ShowDialog();
                this.manager.LoadCategories();
            }
            else
            {
                MessageBox.Show("Please select a category to edit first.");
            }
        }
    }
}
