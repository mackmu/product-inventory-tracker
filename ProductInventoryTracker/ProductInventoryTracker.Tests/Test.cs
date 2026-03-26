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
            var p = new Product(1, "Test", 0m, 10, 1);

            decimal result = p.Subtotal;

            Assert.AreEqual(0m, result);
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
}
