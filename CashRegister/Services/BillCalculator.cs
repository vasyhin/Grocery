using System;
using System.Collections.Generic;
using System.Linq;
using CashRegister.Model.Bill;
using CashRegister.Model.Discounts;

namespace CashRegister.Services
{
    public class BillCalculator
    {
        private readonly IBulkDiscountService _bulkDiscountService;

        public BillCalculator(IBulkDiscountService bulkDiscountService)
        {
            _bulkDiscountService = bulkDiscountService;
        }

        /// <summary>
        /// Returns final bill amount
        /// </summary>
        /// <returns>Final bill amount</returns>
        public decimal GetFinalAmount(Bill bill, IEnumerable<Coupon> coupons)
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
            var originalPrice = GetOriginalAmount(bill);
            var bulkDiscount = GetBulkDiscount(bill);

            return originalPrice - bulkDiscount;
        }

        /// <summary>
        /// Calculate original bill amount (without a discount)
        /// </summary>
        /// <returns>Original bill amount</returns>
        private decimal GetOriginalAmount(Bill bill)
        {
            var price = bill.LineItems.Sum(item => item.Price * item.Quantity);

            return price;
        }

        private decimal GetBulkDiscount(Bill bill)
        {
            var bulkDiscountAmount = bill.LineItems
                .Select(item => new
                {
                    LineItem = item,
                    ItemPrice = item.Price,
                    bulkDiscount = _bulkDiscountService.GetBulkDiscount(item.Name)
                })
                .Sum(item => item.bulkDiscount != null
                                ? ((int)item.LineItem.Quantity / (item.bulkDiscount.BulkItemsCount + item.bulkDiscount.BonusItemsCount)) * item.bulkDiscount.BonusItemsCount * item.ItemPrice
                                : 0);

            return bulkDiscountAmount;
        }

        private decimal ApplyCouponDiscount(IEnumerable<Coupon> coupons, decimal price)
        {
            // TODO: Always take the first coupon for now. List of coupons designed for future functionality
            var coupon = coupons.FirstOrDefault();

            return coupon != null && coupon.Threshold <= price
                ? price - coupon.MoneyOff
                : price;
        }
    }
}