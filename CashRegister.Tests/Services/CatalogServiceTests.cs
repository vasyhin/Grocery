using System;
using CashRegister.Model.Catalog;
using CashRegister.Discounts;
using CashRegister.Services;
using NUnit.Framework;

namespace Tests
{
    public class CatalogServiceTests
    {
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