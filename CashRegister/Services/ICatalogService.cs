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
        /// Registers price for the item
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="price">Price</param>
        void RegisterItemPrice(Item item, decimal price);

        /// <summary>
        /// Returns price of the item
        /// </summary>
        /// <param name="name">Item name</param>
        /// <returns>Price</returns>
        decimal GetItemPrice(string name);

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
