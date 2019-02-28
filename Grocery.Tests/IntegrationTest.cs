using System.Collections.Generic;
using Grocery.Data.Bill;
using Grocery.Data.Catalog;
using Grocery.Discounts;
using Grocery.Services;
using NUnit.Framework;
using Services;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void InterationTest()
        {
            // TODO: Not sure about this test, maybe remove...

            var cs = new CatalogService();
            cs.RegisterItemPrice(new Item("Boxes of Cheerios"), 6.99m);
            cs.RegisterItemPrice(new Item("Apples"), 2.49m);
            cs.RegisterBulkDiscount(new BulkDiscount("Boxes of Cheerios", 2, 1));

            var billCalculator = new BillCalculator(cs);

            var coupons = new[] {
                new Coupon(100, 5)
            };

            var bill = new Bill(new List<LineItem> {
                new LineItem(new Item("Boxes of Cheerios"), 5),
                new LineItem(new Item("Apples"), 1.75m)
            });

            var total = billCalculator.GetPrice(bill, coupons);
            Assert.AreEqual(32.3175, total);
        }
    }
}