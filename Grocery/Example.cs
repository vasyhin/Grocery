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
            cs.RegisterPricePerItem(new Item { Name = "Boxes of Cheerios"}, 6.99m);
            cs.RegisterPricePerWeight(new Item { Name = "Apples" }, 1, 2.49m);
            cs.SetBulkDiscount(new Bulk
            {
                Item = new Item { Name = "Boxes of Cheerios" },
                AmountToBuy = 2,
                AmountToGetFree = 1
            });
            var coupon = new Coupon { Threshhold = 100, MoneyOff = 5 };

            var bill = new Bill(cs)
            {
                Lines = new List<BillLine> {
                    new BillLine
                    {
                        Item = new Item { Name = "Boxes of Cheerios"},
                        Quantity = 5
                    },
                    new BillLine
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
