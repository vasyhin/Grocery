using Grocery.Discounts;
using Grocery.Services;
using System;
using System.Collections.Generic;

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
            var couponDiscount = GetCouponDiscount();
            // TODO: check for negative outcome
            return rawBill - bulkDiscount - couponDiscount;
        }

        private decimal GetCouponDiscount()
        {
            // TODO: always take the first coupon for now. List of coupons is designed for future functionality
            throw new NotImplementedException();
        }

        private decimal GetBulkDiscount()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculate raw bill (without a discount)
        /// </summary>
        /// <returns>Raw bill</returns>
        private decimal GetRawBill()
        {
            throw new NotImplementedException();
        }
    }
}
