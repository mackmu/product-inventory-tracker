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
        private InventoryManager manager;

        // Constructor Overload for 'add' a category.
        public CategoryWindow(InventoryManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        // Constructor Overload for 'edit' a category.
        public CategoryWindow(InventoryManager manager, Category categoryToEdit)
        {
            InitializeComponent();
            this.manager = manager;

            // Pre-fill form fields
            this.Title = "Edit Category";
            txtCategoryName.Text = categoryToEdit.CategoryName;

            // Stash database ID key on the save button
            btnAddCategory.Content = "Save";
            btnAddCategory.Tag = categoryToEdit.CategoryID;
        }

        /// <summary>
        /// Adds a category when category name is succesfully entered.
        /// </summary>
        /// <param name="sender">The object that triggered the event (the button).</param>
        /// <param name="e">The event data.</param>
        private void btnAddCategory_Click(object sender, RoutedEventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Error: Category Name cannot be blank.");
                return;
            }

            // Check if we are Editing vs Adding
            if (btnAddCategory.Tag != null)
            {
                int existingID = (int)btnAddCategory.Tag;
                this.manager.UpdateCategory(existingID, txtCategoryName.Text);
                MessageBox.Show("Category updated successfully!");
            }
            else
            {
                this.manager.AddCategory(txtCategoryName.Text);
                MessageBox.Show("Category added successfully!");
            }

            this.Close();
        }

        /// <summary>
        /// Resets the Category window form fields.
        /// </summary>
        public void ResetProductForm()
        {
            txtCategoryName.Text = "";

            //Reset the cursor to the name field.
            txtCategoryName.Focus();
        }
    }
}
