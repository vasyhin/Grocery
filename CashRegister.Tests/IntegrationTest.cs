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
            cs.RegisterItemPrice(new Item("Cheerios"), 6.99m);
            cs.RegisterItemPrice(new Item("Apples"), 2.49m);
            cs.RegisterBulkDiscount(new BulkDiscount("Cheerios", 2, 1));

            var billCalculator = new BillCalculator(cs);

            var coupons = new[] {
                new Coupon(100, 5)
            };

            var bill = new Bill(new List<LineItem> {
                // comes from cashier
                new LineItem(new Item("Cheerios"), 5),
                // comes from scales
                new LineItem(new Item("Apples"), 1.75m)
            });

            var total = billCalculator.GetPrice(bill, coupons);
            Assert.AreEqual(32.3175, total);
        }
    }
}