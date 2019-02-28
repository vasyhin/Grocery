using CashRegister.Model.Catalog;
using CashRegister.Discounts;
using System;
using System.Collections.Generic;

namespace CashRegister.Services
{
    /// <summary>
    /// CatalogService
    /// </summary>
    public class CatalogService : ICatalogService
    {
        private Dictionary<string, BulkDiscount> _bulkDiscounts = new Dictionary<string, BulkDiscount>();

        /// <summary>
        /// Registers bulk discount
        /// </summary>
        /// <param name="bulk">Bulk discount</param>
        public void RegisterBulkDiscount(BulkDiscount bulk)
        {
            _bulkDiscounts[bulk.ItemName] = bulk;
        }

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
