using Grocery.Data.Bill;
using Grocery.Data.Catalog;
using Grocery.Discounts;
using Grocery.Services;
using System.Collections.Generic;

namespace Grocery
{
    /// <summary>
    /// Example of usage
    /// </summary>
    public class Example
    {
        public static void Test()
        {
            var cs = new CatalogService();
            cs.RegisterItemPrice(new Item { Name = "Boxes of Cheerios"}, 6.99m);
            cs.RegisterItemPrice(new Item { Name = "Apples" }, 2.49m);
            cs.SetBulkDiscount(new BulkDiscount
            {
                Item = new Item { Name = "Boxes of Cheerios" },
                BulkItemsCount = 2,
                BonusItemsCount = 1
            });

            var coupon = new Coupon { Threshold = 100, MoneyOff = 5 };

            var bill = new Bill(cs)
            {
                LineItems = new List<LineItem> {
                    new LineItem
                    {
                        Item = new Item { Name = "Boxes of Cheerios"},
                        Quantity = 5
                    },
                    new LineItem
                    {
                        Item = new Item { Name = "Apples"},
                        Quantity = 1.75m
                    }
                }
            };

            bill.ApplyCoupon(coupon);
            var total = bill.GetTotalBill();
        }
    }
}
