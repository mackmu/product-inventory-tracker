using System;
using System.Collections.Generic;
using System.Text;

namespace ProductInventoryTracker
{
    public class Category
    {
        /// <summary>
        /// Gets or initializes the ID of the category.
        /// </summary>
        public int CategoryID { get; init; }

        /// <summary>
        /// Gets or initializes the category name.
        /// </summary>
        public required string CategoryName { get; init; }
    }
}
