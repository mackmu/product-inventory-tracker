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
    }

    [TestClass]
    public class CategoryClassTests
    {
        [TestMethod]
        public void GetName()
        {
            var c = new Category(32, "Hats");

            Assert.AreEqual("Hats", c.GetCategoryName);
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
