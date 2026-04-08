using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ProductInventoryTracker.Tests
{
    [TestClass]
    public class ProductClassTests
    {
        [TestMethod]
        public void CalculateSubtotal()
        {
            var p = new Product(1, "test", 3.14m, 99, 1);

            Assert.AreEqual(310.86m, p.Subtotal);
        }

        [TestMethod]
        public void CalculateSubtotal_WithZero_ReturnsZero()
        {
            // 1. Arrange
            var p = new Product(1, "Test", 0m, 10, 1);

            // 2. Act
            decimal result = p.Subtotal;

            // 3. Assert
            Assert.AreEqual(0m, result);
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
        public void ToStringReturns_ExpectedResult()
        {
            var p = new Product(1, "Test", 0m, 10, 1);

            var result = p.ToString();

            Assert.AreEqual("", result);
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
            Supplier s = new Supplier(0, "", "test@email.com");

            // 2. Act
            bool result = s.IsNameValid;

            // 3. Assert
            Assert.IsFalse(result);
        }
    }


}
