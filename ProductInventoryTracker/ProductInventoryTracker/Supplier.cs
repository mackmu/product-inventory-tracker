using System;
using System.Collections.Generic;
using System.Text;

namespace ProductInventoryTracker
{
    public class Supplier
    {
        /// <summary>
        /// ID of the supplier.
        /// </summary>
        private int supplierID;

        /// <summary>
        /// Name of the supplier.
        /// </summary>
        private string supplierName;

        /// <summary>
        /// Email address of the supplier.
        /// </summary>
        private string supplierEmail;

        /// <summary>
        /// Supplier class constructor that initializes the supplier's ID, name, and email address.
        /// </summary>
        /// <param name="supplierID"></param>
        /// <param name="supplierName"></param>
        /// <param name="supplierEmail"></param>
        public Supplier(int supplierID, string supplierName, string supplierEmail)
        {
            this.supplierID = supplierID;
            this.supplierName = supplierName;
            this.supplierEmail = supplierEmail;
        }

        /// <summary>
        /// Gets a value indicating whether the Supplier Name is not empty (valid) or empty (not valid).
        /// </summary>
        public bool IsNameValid
        {
            get
            {
                // Logic: If the name is NOT equal to empty quotes, it's valid
                if (this.supplierName != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
