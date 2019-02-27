using Grocery.Discounts;
using Grocery.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Grocery.Data.Bill
{
    /// <summary>
    /// Represents the bill
    /// </summary>
    public class Bill
    {
        /// <summary>
        /// List of bill lines
        /// </summary>
        public List<LineItem> LineItems { get; set; }

        /// <summary>
        /// Applied coupons
        /// </summary>
        private List<Coupon> _coupons;

        /// <summary>
        /// Catalog service reference
        /// </summary>
        private ICatalogService _catalogService;

        /// <summary>
        /// Returns bill amount
        /// </summary>
        public decimal TotalAmount => GetTotalBill();

        /// <summary>
        /// Creates instances of the bill
        /// </summary>
        /// <param name="catalogService">Catalog service</param>
        public Bill(ICatalogService catalogService)
        {
            _catalogService = catalogService;
            _coupons = new List<Coupon>();
        }

        /// <summary>
        /// Applies coupon for the bill
        /// </summary>
        /// <param name="coupon">Coupon to apply</param>
        public void ApplyCoupon(Coupon coupon)
        {
            _coupons.Add(coupon);
        }

        /// <summary>
        /// Returns total bill
        /// </summary>
        /// <returns>Total bill</returns>
        public decimal GetTotalBill()
        {
            var rawBill = GetRawBill();
            var bulkDiscount = GetBulkDiscount();
            var couponDiscount = GetCouponDiscount(rawBill - bulkDiscount);
            var total = rawBill - bulkDiscount - couponDiscount;

            return total > 0 ? total : 0;
        }

        private decimal GetCouponDiscount(decimal total)
        {
            // TODO: always take the first coupon for now. List of coupons is designed for future functionality            
            var coupon = _coupons.FirstOrDefault();

            var couponDiscount = coupon != null && coupon.Threshold <= total 
                                    ? coupon.MoneyOff 
                                    : 0;

            return couponDiscount;
        }

        private decimal GetBulkDiscount()
        {
            var bulkDiscountAmount = LineItems
                .Select(item => new
                {
                    LineItem = item,
                    ItemPrice = _catalogService.GetItemPrice(item.Item.Name),
                    bulkDiscount = _catalogService.GetBulkDiscount(item.Item.Name)
                })
                .Sum(item => item.bulkDiscount != null 
                                ? ((int)item.LineItem.Quantity / (item.bulkDiscount.BulkItemsCount + item.bulkDiscount.BonusItemsCount)) * item.bulkDiscount.BonusItemsCount * item.ItemPrice
                                : 0);

            return bulkDiscountAmount;
        }

        /// <summary>
        /// Calculate raw bill (without a discount)
        /// </summary>
        /// <returns>Raw bill</returns>
        private decimal GetRawBill()
        {
            var rawBill = LineItems.Sum(item => _catalogService.GetItemPrice(item.Item.Name) * item.Quantity);
            return rawBill;
        }
    }
}
