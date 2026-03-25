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
}
