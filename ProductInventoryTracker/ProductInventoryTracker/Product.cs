using System;
using System.Collections.Generic;
using System.Text;


namespace ProductInventoryTracker
{
    /// <summary>
    /// Represents a product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Name of the product.
        /// </summary>
        private string productName;

        /// <summary>
        /// ID of the product.
        /// </summary>
        private int productID;

        /// <summary>
        /// Quantity of the product in stock.
        /// </summary>
        private int quantity;

        /// <summary>
        /// Price of the product.
        /// </summary>
        private decimal price;

        /// <summary>
        /// ID of the category to which the product belongs.
        /// </summary>
        private int categoryID;

        /// <summary>
        /// ID of the supplier that provides the product.
        /// </summary>
        private int supplierID;

        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        /// <param name="productID">The unique identifier for the product. Must be a positive integer.</param>
        /// <param name="productName">The name of the product. Cannot be null or empty.</param>
        /// <param name="price">The price of the product. Must be greater than or equal to zero.</param>
        /// <param name="quantity">The quantity of the product in stock. Must be zero or a positive integer.</param>
        /// <param name="categoryID">The identifier for the category to which the product belongs. Must be a positive integer.</param>
        public Product(int productID, string productName, decimal price, int quantity, int categoryID)
        {
            Price = price;
            Quantity = quantity;
            this.productID = productID;
            this.categoryID = categoryID;
            this.productName = productName;
        }

        /// <summary>
        /// Gets the subtotal calculation based on the product of price and quantity.
        /// </summary>
        public decimal Subtotal
        {
            get => this.price * this.quantity;
        }

        // Price validation
        public decimal Price
        {
            get => this.price;

            set
            {
                if (value <= 0 || value > 1000)
                    throw new ArgumentOutOfRangeException("Please provide a value that between 0 and 1000.");

                this.price = value;
            }
        }

        // Quantity validation
        public int Quantity
        {
            get => this.quantity;

            set
            {
                if (value <= 0 || value > 1000)
                    throw new ArgumentOutOfRangeException("Please provide a value that between 0 and 1000.");

                this.quantity = value;
            }
        }

        // Updates the product quanity
        public void UpdateStock(int amount)
        {
            this.Quantity += amount;
        }

        // Product details
        public override string ToString()
        {
            return $"{this.productName} {this.productID}, price {this.price}, quantity {this.quantity}";
        }
    }
}
