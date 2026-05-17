using System;
using System.Collections.Generic;
using System.Text;

namespace ProductInventoryTracker
{
    public class Category
    {
        private string _categoryName;

        /// <summary>
        /// Category Constructor
        /// </summary>
        public Category(int categoryID, string categoryName)
        {
            this._categoryName = string.Empty;
            this.CategoryID = categoryID;
            this.CategoryName = categoryName;
        }

        /// <summary>
        /// Gets or initializes the ID of the category.
        /// </summary>
        public int CategoryID { get; init; }

        /// <summary>
        /// Gets or initializes the category name.
        /// </summary>
        public string CategoryName
        {
            get
            {
                if (string.IsNullOrEmpty(_categoryName))
                    throw new Exception("CategoryName is required.");
                return _categoryName;
            }
            init
            {
                _categoryName = value;
            }
        }
    }
}
