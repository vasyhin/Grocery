using CashRegister.Model.Discounts;
using CashRegister.Services;
using NUnit.Framework;

namespace CashRegisterTests.Model.Services
{
    public class BulkDiscountServiceTests
    {
        [Test]
        public void GetBulkDiscount_IfDiscountRegistered_ShouldReturnValidDiscount()
        {
            var bulkDiscountService = new BulkDiscountService();

            bulkDiscountService.RegisterBulkDiscount(new BulkDiscount("product a", 5, 2));
            var discount = bulkDiscountService.GetBulkDiscount("product a");

            Assert.NotNull(discount);
            Assert.AreEqual("product a", discount.ItemName);
            Assert.AreEqual(5, discount.BulkItemsCount);
            Assert.AreEqual(2, discount.BonusItemsCount);
        }

        [Test]
        public void GetBulkDiscount_IfDiscountNotRegistered_ShouldReturnNull()
        {
            var bulkDiscountService = new BulkDiscountService();

            bulkDiscountService.RegisterBulkDiscount(new BulkDiscount("product a", 5, 2));
            var discount = bulkDiscountService.GetBulkDiscount("product b");

            Assert.Null(discount);
        }
    }
}