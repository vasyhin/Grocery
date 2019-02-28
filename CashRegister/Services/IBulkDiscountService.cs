using CashRegister.Model.Discounts;

namespace CashRegister.Services
{
    /// <summary>
    /// Defines interface to work with Bul Discount Service
    /// </summary>
    public interface IBulkDiscountService
    {
        /// <summary>
        /// Registers bulk discount
        /// </summary>
        /// <param name="bulk">Bulk discount</param>
        void RegisterBulkDiscount(BulkDiscount bulk);

        /// <summary>
        /// Returns bulk discount for item or null if no discount for the item exists
        /// </summary>
        /// <returns>Bulk discount or null if not found</returns>
        BulkDiscount GetBulkDiscount(string name);
    }
}
