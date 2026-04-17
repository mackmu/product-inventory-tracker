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
        /// Phone Number of the supplier.
        /// </summary>
        private string supplierPhone;

        /// <summary>
        /// Supplier class constructor that initializes the supplier's ID, name, and email address.
        /// </summary>
        /// <param name="supplierID"></param>
        /// <param name="supplierName"></param>
        /// <param name="supplierEmail"></param>
        /// <param name="supplierPhone"></param>
        public Supplier(int supplierID, string supplierName, string supplierEmail, string supplierPhone)
        {
            this.supplierID = supplierID;
            this.supplierName = supplierName;
            this.supplierEmail = supplierEmail;
            this.supplierPhone = supplierPhone;
        }

        /// <summary>
        /// Gets and sets the supplier's ID.
        /// </summary>
        public int SupplierID
        {
            get
            {
                return this.supplierID;
            }
            set
            {
                this.supplierID = value;
            }
        }

        /// <summary>
        /// Gets and sets the supplier's email.
        /// </summary>
        public string SupplierEmail
        {
            get
            {
                return this.supplierEmail;
            }
            set
            {
                this.supplierEmail = value;
            }
        }

        /// <summary>
        /// Gets and sets the supplier's name.
        /// </summary>
        public string SupplierName
        {
            get
            {
                return this.supplierName;
            }
            set
            {
                this.supplierName = value;
            }
        }

        /// <summary>
        /// Gets and sets the supplier's phone number.
        /// </summary>
        public string SupplierPhone
        {
            get
            {
                return this.supplierPhone;
            }
            set
            {
                this.supplierPhone = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the supplier's ID is valid.
        /// </summary>
        public bool IsIDValid
        {
            get
            {
                if(this.supplierID > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the supplier's name is valid.
        /// </summary>
        public bool IsNameValid
        {
            get
            {
                if (this.supplierName != null && this.supplierName != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        ///  Gets a value indicating whether the supplier's email address is valid.
        /// </summary>
        public bool IsEmailValid
        {
            get
            {
                if (this.supplierEmail != null && this.supplierEmail != "" && this.supplierEmail.Contains('@'))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the supplier's phone number is valid.
        /// </summary>
        public bool IsPhoneValid
        {
            get
            {
                if (this.supplierPhone != null && this.supplierPhone != "")
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
