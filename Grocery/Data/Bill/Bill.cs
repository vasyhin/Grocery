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
        /// Name of the item
        /// </summary>
        public List<BillLine> Lines { get; set; }

        /// <summary>
        /// Applied coupon
        /// </summary>
        private Coupon _coupon;

        /// <summary>
        /// Catalog service reference
        /// </summary>
        private ICatalogService _catalogService;

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
            _coupon = coupon;
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
