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
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens the Product window when the Products button is clicked.
        /// </summary>
        /// <param name="sender">The object that triggered the event (the button).</param>
        /// <param name="e">The event data.</param>
        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow pw = new ProductWindow();

            pw.ShowDialog();
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
            SupplierWindow sw = new SupplierWindow();

            sw.ShowDialog();
        }
    }
}