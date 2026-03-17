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
        private double price;

        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        /// <param name="productID">The unique identifier for the product. Must be a positive integer.</param>
        /// <param name="productName">The name of the product. Cannot be null or empty.</param>
        /// <param name="price">The price of the product. Must be greater than or equal to zero.</param>
        /// <param name="quantity">The quantity of the product in stock. Must be zero or a positive integer.</param>
        public Product(int productID, string productName, double price, int quantity)
        {
            this.productID = productID;
            this.productName = productName;
            this.price = price;
            this.quantity = quantity;
        }
    }
}
