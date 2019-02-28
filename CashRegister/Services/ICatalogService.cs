using CashRegister.Model.Catalog;
using CashRegister.Discounts;
using System;

namespace CashRegister.Services
{
    /// <summary>
    /// Defines interface to work with CatalogService
    /// </summary>
    public interface ICatalogService
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
