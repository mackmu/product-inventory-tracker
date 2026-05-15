using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductInventoryTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private InventoryManager inventoryManager;
        public MainWindow()
        {
            InitializeComponent();
            this.inventoryManager = new InventoryManager();
            this.tProductsLabel.Content = this.inventoryManager.TotalProductCount();
        }

        /// <summary>
        /// Opens the Product window when the Products button is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event (the button).</param>
        /// <param name="e">The event data.</param>
        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductManagementWindow pnw = new ProductManagementWindow(this.inventoryManager);

            pnw.ShowDialog();
        }

        /// <summary>
        /// Opens the Category window when the Categories button is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event (the button).</param>
        /// <param name="e">The event data.</param>
        private void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            CategoryWindow cw = new CategoryWindow();

            cw.ShowDialog();
        }

        /// <summary>
        /// Opens the Supplier window when the Suppliers button is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event (the button).</param>
        /// <param name="e">The event data.</param>
        private void btnSuppliers_Click(object sender, RoutedEventArgs e)
        {
            SupplierWindow sw = new SupplierWindow(this.inventoryManager);

            sw.ShowDialog();
        }

        /// <summary>
        /// Bulletin Board text change event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBulletinBoard_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Placeholder where future logic for the Main Window "Bulletin Board" text could go.
        }

        private void txtBulletinBoard_GotFocus(object sender, RoutedEventArgs e)
        {
            // Checks to see is the user is clicking inside of the Bulletin Board textbox.
            if (txtBulletinBoard.Text == "Click here... add notes, jot down daily goals or product updates for your team")
            {
                txtBulletinBoard.Text = ""; // clears text.
                txtBulletinBoard.Foreground = Brushes.Black; //sets text color.
                txtBulletinBoard.FontStyle = FontStyles.Normal; // Removes italics set in placeholder text.
            }
        }

        private void txtBulletinBoard_LostFocus(object sender, RoutedEventArgs e)
        {
            // Checks if the user leaves the Bulletin Board textbox empty.
            if (string.IsNullOrWhiteSpace(txtBulletinBoard.Text))
            {
                txtBulletinBoard.Text = "Click here... add notes, jot down daily goals or product updates for your team"; // Restores placeholder text.
                txtBulletinBoard.Foreground = Brushes.Gray; // Restores text color.
                txtBulletinBoard.FontStyle = FontStyles.Italic; // Restores italics.
            }
        }
    }
}