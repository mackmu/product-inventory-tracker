namespace ProductInventoryTracker.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void CalculateSubtotal()
        {
            var p = new Product(1, "test", 3.14m, 99, 1);

            Assert.AreEqual(310.86m, p.Subtotal);
        }
    }
}
