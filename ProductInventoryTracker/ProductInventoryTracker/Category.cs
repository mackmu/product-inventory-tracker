using System;
using System.Collections.Generic;
using System.Text;

namespace ProductInventoryTracker
{
    /// <summary>
    /// Represents a classification or grouping used to organize related items or entities.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// ID of the category.
        /// </summary>
        private int categoryID;

        /// <summary>
        /// Name of the category.
        /// </summary>
        private string categoryName;

        /// <summary>
        /// Initializes a new instance of the Category class with the specified category identifier and name.
        /// </summary>
        /// <param name="categoryID">The unique identifier for the category. Must be a non-negative integer.</param>
        /// <param name="categoryName">The name of the category. Cannot be null or empty.</param>
        public Category(int categoryID, string categoryName)
        {
            this.categoryID = categoryID;
            this.categoryName = categoryName;
        }

        public string GetCategoryName { get => this.categoryName; }
    }
}
