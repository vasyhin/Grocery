using System;
using System.Collections.Generic;
using System.Linq;
using CashRegister.Model.Bill;
using CashRegister.Discounts;
using CashRegister.Services;

namespace Services
{
    public class BillCalculator
    {
        private readonly ICatalogService _catalogService;

        public BillCalculator(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        /// <summary>
        /// Returns total bill
        /// </summary>
        /// <returns>Total bill</returns>
        public decimal GetPrice(Bill bill, IEnumerable<Coupon> coupons)
        {
            var price = GetDiscountedPrice(bill);

            if (coupons != null && coupons.Count() > 0)
            {
                price = ApplyCouponDiscount(coupons, price);
            }

            return Math.Max(price, 0);
        }

        /// <summary>
        /// Get discounted price for bill
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        private decimal GetDiscountedPrice(Bill bill)
        {
            var rawPrice = GetRawPrice(bill);
            var bulkDiscount = GetBulkDiscount(bill);

            return rawPrice - bulkDiscount;
        }

        /// <summary>
        /// Calculate raw price (without a discount)
        /// </summary>
        /// <returns>Raw price</returns>
        private decimal GetRawPrice(Bill bill)
        {
            var price = bill.LineItems.Sum(item => _catalogService.GetItemPrice(item.Item.Name) * item.Quantity);

            return price;
        }

        private decimal GetBulkDiscount(Bill bill)
        {
            var bulkDiscountAmount = bill.LineItems
                .Select(item => new
                {
                    Quantity = item.Quantity,
                    ItemPrice = _catalogService.GetItemPrice(item.Item.Name),
                    bulkDiscount = _catalogService.GetBulkDiscount(item.Item.Name)
                })
                .Where(i => i.bulkDiscount != null && i.Quantity > i.bulkDiscount.BulkItemsCount)
                .Sum(item =>
                {
                    var discount = item.bulkDiscount;
                    var itemsToDiscount = Math.Min(item.Quantity - discount.BulkItemsCount, discount.BonusItemsCount);

                    return itemsToDiscount * item.ItemPrice;
                });

            return bulkDiscountAmount;
        }

        private decimal ApplyCouponDiscount(IEnumerable<Coupon> coupons, decimal price)
        {
            // always take the first coupon for now. List of coupons is designed for future functionality
            var coupon = coupons.FirstOrDefault();

            return coupon != null && coupon.Threshold <= price
                ? price - coupon.MoneyOff
                : price;
        }
    }
}