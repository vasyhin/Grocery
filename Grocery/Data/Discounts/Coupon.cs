using Grocery.Services;

namespace Grocery.Discounts
{
    /// <summary>
    /// Represents bulk discount
    /// </summary>
    public class Coupon : Discount
    {
        /// <summary>
        /// The total bill which should be reached to apply this coupon
        /// </summary>
        public decimal Threshhold { get; set; }

        /// <summary>
        /// The amount of money to decrease the bill using this coupon
        /// </summary>
        public decimal MoneyOff{ get; set; }

        public override decimal ApplyDiscount(ICatalogService catalogService)
        {
            throw new NotImplementedException();
        }
    }
}
