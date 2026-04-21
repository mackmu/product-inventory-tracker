using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ProductInventoryTracker.Tests
{
    [TestClass]
    public class InventoryManagerTests
    {
        [TestMethod]
        public void AddProduct_ShouldIncreaseListCount()
        {
            // 1. ARRANGE
            InventoryManager manager = new InventoryManager();
            Product testProduct = new Product(1, "Test Item", 10.00m, 5, 1);

            // 2. ACT
            manager.ProductList.Add(testProduct);

            // 3. ASSERT
            Assert.HasCount(1, manager.ProductList);
        }
    }

    [TestClass]
    public class ProductClassTests
    {
        [TestMethod]
        public void CalculateSubtotal()
        {
            var p = new Product(1, "test", 3.14m, 99, 1);

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

            // Act
            try 
            {
                new Product(id, name, illegalPrice, qty, catID);

                // Assert
                Assert.Fail("The constructor should have thrown an error for zero price");
            }
            catch (ArgumentOutOfRangeException) { }
        }

        [TestMethod]
        public void Price_Vaidation()
        {
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => {
                var p = new Product(1, "Test", 0m, 10, 1);
            });

            var p = new Product(1, "Test", 10.45m, 10, 1);

            Assert.AreEqual(10.45m, p.Price);
        }

        [TestMethod]
        public void UpdateStock_Check()
        {
            var p = new Product(1, "Test", 10.45m, 10, 1);

            p.UpdateStock(38);

            Assert.AreEqual(48, p.Quantity);
        }

        [TestMethod]
        public void ToStringReturns_ExpectedResult()
        {
            // Arrange
            var p = new Product(1, "Test Product", 10m, 5, 1);

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
            var category = new Category { CategoryID = 1123, CategoryName = "Cars" };

            Assert.AreEqual("Cars", category.CategoryName);
        }

    }

    [TestClass]
    public class SupplierClassTests
    {
        [TestMethod]
        public void IsNameValid_EmptyName_ReturnsFalse()
        {
            // 1. Arrange
            Supplier s = new Supplier(0, "", "test@email.com", "0000000000");

            // 2. Act
            bool result = s.IsNameValid;

            // 3. Assert
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
    }


}
