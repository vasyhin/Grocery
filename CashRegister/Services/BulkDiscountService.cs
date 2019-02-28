using CashRegister.Model.Discounts;
using System.Collections.Generic;

namespace CashRegister.Services
{
    /// <inheritdoc />
    /// <summary>
    /// Bulk Discount Service
    /// </summary>
    public class BulkDiscountService : IBulkDiscountService
    {
        private Dictionary<string, BulkDiscount> _bulkDiscounts = new Dictionary<string, BulkDiscount>();

        /// <inheritdoc />
        /// <summary>
        /// Registers bulk discount
        /// </summary>
        /// <param name="bulk">Bulk discount</param>
        public void RegisterBulkDiscount(BulkDiscount bulk) => _bulkDiscounts[bulk.ItemName] = bulk;

        /// <inheritdoc />
        /// <summary>
        /// Returns bulk discount for item or null if no discount for the item exists
        /// </summary>
        /// <returns>Bulk discount or null if not found</returns>
        public BulkDiscount GetBulkDiscount(string name)
        {
            if (_bulkDiscounts.ContainsKey(name))
             return _bulkDiscounts[name];

            return null;
        }
    }
}
