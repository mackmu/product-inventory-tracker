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
    /// Interaction logic for SupplierWindow.xaml.
    /// </summary>
    public partial class AddSupplierWindow : Window
    {
        private InventoryManager manager;

        // First constructor to 'add' objects (Constructor Overload).
        public AddSupplierWindow(InventoryManager manager)
        {
            InitializeComponent();
            this.manager = manager;

        }

        // Second constructor to 'edit' objects (Constructor Overload).
        public AddSupplierWindow(InventoryManager manager, Supplier supplierToEdit)
        {
            InitializeComponent();
            this.manager = manager;

            // 1. Change window header text when editing
            this.Title = "Edit Supplier";

            // 2. Data text fields from form boxes.
            txtSupplierName.Text = supplierToEdit.SupplierName;
            txtSupplierEmail.Text = supplierToEdit.SupplierEmail;
            txtSupplierPhone.Text = supplierToEdit.SupplierPhone;

            // 3. Grabs the primary key ID on the Save button click.
            btnSaveSupplier.Tag = supplierToEdit.SupplierID;

        }

        /// <summary>
        /// Saves a supplier when supplier info is succesfully entered.
        /// </summary>
        /// <param name="sender">The object that triggered the event (the button).</param>
        /// <param name="e">The event data.</param>
        private void btnSaveSupplier_Click(object sender, RoutedEventArgs e)
        {
            Supplier tempSupplier = new Supplier(0, txtSupplierName.Text, txtSupplierEmail.Text, txtSupplierPhone.Text);

            if (tempSupplier.IsNameValid == true && tempSupplier.IsEmailValid == true && tempSupplier.IsPhoneValid == true)
            {
                // Check if there is an ID from the Edit constructor.
                if (btnSaveSupplier.Tag != null)
                {
                    int existingID = (int)btnSaveSupplier.Tag;

                    this.manager.UpdateSupplier(existingID, txtSupplierName.Text, txtSupplierEmail.Text, txtSupplierPhone.Text);
                    MessageBox.Show("Supplier updated successfully!");
                }
                else
                {
                    // 2. Otherwise, perform the normal Add process
                    this.manager.AddSupplier(txtSupplierName.Text, txtSupplierEmail.Text, txtSupplierPhone.Text);
                    MessageBox.Show("Supplier saved successfully!");
                }

                this.ResetSupplierForm();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Supplier Name cannot be blank.");
            }
        }

        private void txtSupplierPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            // If the user is deleting (backspacing), don't force the formatting.
            if (e.Changes.Any(c => c.RemovedLength > 0 && c.AddedLength == 0))
            {
                return;
            }

            // 1. Get just the digits from the current text.
            string digitsOnly = new string(txtSupplierPhone.Text.Where(char.IsDigit).ToArray());

            string formatted = "";

            // 2. Build the format based on length.
            if (digitsOnly.Length > 0)
            {
                if (digitsOnly.Length < 3)
                    formatted = $"({digitsOnly}";
                else if (digitsOnly.Length <= 6)
                    formatted = $"({digitsOnly.Substring(0, 3)}) {digitsOnly.Substring(3)}";
                else
                    formatted = $"({digitsOnly.Substring(0, 3)}) {digitsOnly.Substring(3, 3)}-{digitsOnly.Substring(6, Math.Min(4, digitsOnly.Length - 6))}";
            }

            // 3. Update the text box with the formatted version.
            if (txtSupplierPhone.Text != formatted)
            {
                txtSupplierPhone.Text = formatted;

                // This line is important so the cursor doesn't jump to the start.
                txtSupplierPhone.SelectionStart = txtSupplierPhone.Text.Length;
            }
        }

        /// <summary>
        /// Resets the Supplier window form fields.
        /// </summary>
        private void ResetSupplierForm()
        {
            // Clear name, email and phone.
            txtSupplierName.Text = "";
            txtSupplierEmail.Text = "";
            txtSupplierPhone.Text = "";

            //Reset the cursor to the name field.
            txtSupplierName.Focus();
        }
    }
}
