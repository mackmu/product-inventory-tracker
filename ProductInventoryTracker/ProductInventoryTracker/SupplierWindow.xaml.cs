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
            Supplier tempSupplier = new Supplier(0, txtSupplierName.Text, txtSupplierEmail.Text, txtSupplierPhone.Text);

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

        private void txtSupplierPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            // If the user is deleting (backspacing), don't force the formatting
            if (e.Changes.Any(c => c.RemovedLength > 0 && c.AddedLength == 0))
            {
                return;
            }

            // 1. Get just the digits from the current text
            string digitsOnly = new string(txtSupplierPhone.Text.Where(char.IsDigit).ToArray());

            string formatted = "";

            // 2. Build the format based on length
            if (digitsOnly.Length > 0)
            {
                if (digitsOnly.Length < 3)
                    formatted = $"({digitsOnly}";
                else if (digitsOnly.Length <= 6)
                    formatted = $"({digitsOnly.Substring(0, 3)}) {digitsOnly.Substring(3)}";
                else
                    formatted = $"({digitsOnly.Substring(0, 3)}) {digitsOnly.Substring(3, 3)}-{digitsOnly.Substring(6, Math.Min(4, digitsOnly.Length - 6))}";
            }

            // 3. Update the text box with the formatted version
            if (txtSupplierPhone.Text != formatted)
            {
                txtSupplierPhone.Text = formatted;

                // This line is super important so the cursor doesn't jump to the start!
                txtSupplierPhone.SelectionStart = txtSupplierPhone.Text.Length;
            }
        }
    }
}
