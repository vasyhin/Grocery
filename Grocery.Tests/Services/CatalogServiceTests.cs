using System;
using Grocery.Data.Catalog;
using Grocery.Discounts;
using Grocery.Services;
using NUnit.Framework;

namespace Tests
{
    public class CatalogServiceTests
    {
        [Test]
        public void RegisterItemPrice_RegisterNullItem_ShouldThrowInvalidOperationException()
        {
            var catalogService = new CatalogService();

            TestDelegate action = () => catalogService.RegisterItemPrice(null, 0m);

            Assert.Throws<InvalidOperationException>(action);
        }

        [Test]
        public void GetItemPrice_IfProductRegistered_ShouldReturnValidPrice()
        {
            var catalogService = new CatalogService();

            catalogService.RegisterItemPrice(new Item("product a"), 100m);
            var price = catalogService.GetItemPrice("product a");

            Assert.AreEqual(100m, price);
        }

        [Test]
        public void GetItemPrice_IfPRoductNotRegistered_ShouldThrowInvalidOperationException()
        {
            var catalogService = new CatalogService();

            catalogService.RegisterItemPrice(new Item("product a"), 100m);
            TestDelegate action = () => catalogService.GetItemPrice("product b");

            Assert.Throws<InvalidOperationException>(action);
        }

        [Test]
        public void GetBulkDiscount_IfDiscountRegistered_ShouldReturnValidDiscount()
        {
            var catalogService = new CatalogService();

            catalogService.RegisterBulkDiscount(new BulkDiscount("product a", 5, 2));
            var discount = catalogService.GetBulkDiscount("product a");

            Assert.NotNull(discount);
            Assert.AreEqual("product a", discount.ItemName);
            Assert.AreEqual(5, discount.BulkItemsCount);
            Assert.AreEqual(2, discount.BonusItemsCount);
        }

        [Test]
        public void GetBulkDiscount_IfDiscountNotRegistered_ShouldReturnNull()
        {
            var catalogService = new CatalogService();

            catalogService.RegisterBulkDiscount(new BulkDiscount("product a", 5, 2));
            var discount = catalogService.GetBulkDiscount("product b");

            Assert.Null(discount);
        }
    }
}