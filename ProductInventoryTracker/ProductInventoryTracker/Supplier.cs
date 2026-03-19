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
        private string suplierName;

        /// <summary>
        /// Email address of the supplier.
        /// </summary>
        private string supplierEmail;

        /// <summary>
        /// Supplier class constructor that initializes the supplier's ID, name, and email address.
        /// </summary>
        /// <param name="supplierID"></param>
        /// <param name="suplierName"></param>
        /// <param name="supplierEmail"></param>
        public Supplier(int supplierID, string suplierName, string supplierEmail)
        {
            this.supplierID = supplierID;
            this.suplierName = suplierName;
            this.supplierEmail = supplierEmail;
        }
    }
}
