using System.Collections.Generic;
using CashRegister.Model.Bill;
using CashRegister.Model.Catalog;
using CashRegister.Discounts;
using CashRegister.Services;
using NUnit.Framework;
using Services;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void IntegrationTest()
        {
            var cs = new CatalogService();
            cs.RegisterBulkDiscount(new BulkDiscount("Cheerios", 2, 1));

            var billCalculator = new BillCalculator(cs);

            var coupons = new[] {
                new Coupon(100, 5)
            };

            var bill = new Bill(new List<LineItem> {
                // comes from cashier
                new LineItem("Cheerios", 6.99m, 5),
                // comes from scales
                new LineItem("Apples", 2.49m, 1.75m)
            });

            var total = billCalculator.GetFinalAmount(bill, coupons);
            Assert.AreEqual(32.3175, total);
        }
    }
}