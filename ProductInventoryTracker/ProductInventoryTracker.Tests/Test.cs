using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ProductInventoryTracker.Tests
{
    [TestClass]
    public class InventoryManagerTests
    {
        [TestMethod]
        public void AddProduct_ShouldIncreaseListCount()
        {
            // Arrange. Create the list.
            var testList = new System.Collections.Generic.List<Product>();
            Product testProduct = new Product(1, "Test Item", 10.00m, 5, 1, 1);

            // Act. Add the product.
            testList.Add(testProduct);

            // Assert. Verify the logic.
            Assert.HasCount(1, testList);
        }

        [TestMethod]
        public void AddSupply_ShouldIncreaseListCount()
        {
            // Arrange. Create the list.
            var testList = new System.Collections.Generic.List<Supplier>();
            Supplier testSupplier = new Supplier(1, "Test Item", "123@gmail.com", "123-456-7890");

            // Act. Add the supplier.
            testList.Add(testSupplier);

            // Assert. Verify the logic.
            Assert.HasCount(1, testList);
        }

        [TestMethod]
        public void ToString_Return()
        {
            // Arrange
            Supplier testSupplier = new Supplier(1, "Test Item", "123@gmail.com", "123-456-7890");

            // Arrange
            int productCount = 0;
            int supplierCount = 1;

            // Act
            string result = $"{productCount} Products and {supplierCount} Suppliers";

            // Assert
            Assert.AreEqual("0 Products and 1 Suppliers", result);
        }
    }

    [TestClass]
    public class ProductClassTests
    {
        [TestMethod]
        public void CalculateSubtotal()
        {
            var p = new Product(1, "test", 3.14m, 99, 1, 1);

            Assert.AreEqual(310.86m, p.Subtotal);
        }

        /// <summary>
        /// Test that price cannot be 0.
        /// </summary>
        [TestMethod]
        public void Price_SetToZero_ThrowsException()
        {
            // Arrange
            int id = 1;
            string name = "Test Product";
            decimal illegalPrice = 0m;
            int qty = 10;
            int catID = 1;
            int supID = 1;

            // Act
            try 
            {
                new Product(id, name, illegalPrice, qty, catID, supID);

                // Assert
                Assert.Fail("The constructor should have thrown an error for zero price");
            }
            catch (ArgumentOutOfRangeException) { }
        }

        [TestMethod]
        public void Price_Vaidation()
        {
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => {
                var p = new Product(1, "Test", 0m, 10, 1, 1);
            });

            var p = new Product(1, "Test", 10.45m, 10, 1, 1);

            Assert.AreEqual(10.45m, p.Price);
        }

        [TestMethod]
        public void UpdateStock_Check()
        {
            var p = new Product(1, "Test", 10.45m, 10, 1, 1);

            p.UpdateStock(38);

            Assert.AreEqual(48, p.Quantity);
        }

        [TestMethod]
        public void ToStringReturns_ExpectedResult()
        {
            // Arrange
            var p = new Product(1, "Test Product", 10m, 5, 1, 1);

            // Act
            var result = p.ToString();

            //Assert
            Assert.AreEqual("Test Product 1, price 10, quantity 5", result);
        }
    }
  
    [TestClass]
    public class CategoryClassTests
    {
        [TestMethod]
        public void GetCategoryName()
        {
            var category = new Category(1123, "Cars");

            Assert.AreEqual("Cars", category.CategoryName);
        }

    }

    [TestClass]
    public class SupplierClassTests
    {
        [TestMethod]
        public void IsNameValid_EmptyName_ReturnsFalse()
        {
            // Arrange
            Supplier s = new Supplier(0, "", "test@email.com", "0000000000");

            // Act
            bool result = s.IsNameValid;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsNameValid_WithActualName_ReturnsTrue()
        {
            // 1. Arrange
            Supplier s = new Supplier(1, "Test Supplier", "test@email.com", "1234567890");

            // 2. Act
            bool result = s.IsNameValid;

            // 3. Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsEmailValid_MissingAtSymbol_ReturnsFalse()
        {
            // ARRANGE
            Supplier testSupplier = new Supplier(1, "Test Supplier", "manager-at-mke-inventory.com", "1234567890");
            testSupplier.SupplierEmail = "manager-at-mke-inventory.com"; // Missing @

            // ACT
            bool result = testSupplier.IsEmailValid;

            // ASSERT
            Assert.IsFalse(result);
        }
    }


}
