using Grocery.Data.Catalog;
using Grocery.Discounts;
using System;

namespace Grocery.Services
{
    /// <summary>
    /// Defines interface to work with CatalogService
    /// </summary>
    public interface ICatalogService
    {
        /// <summary>
        /// Registers price per item for the item
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="price">Price</param>
        void RegisterPricePerItem(Item item, decimal price);

        /// <summary>
        /// Registers price per weight for the item
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="weight">Weight for which price is specified</param>
        /// <param name="price">Price</param>
        void RegisterPricePerWeight(Item item, decimal weight, decimal price);

        /// <summary>
        /// Returns price of item which is sold per item
        /// </summary>
        /// <param name="name">Item name</param>
        /// <returns>Price per item</returns>
        decimal GetPricePerItem(string name);

        /// <summary>
        /// Returns price of item which is sold per weight
        /// </summary>
        /// <param name="name">Item name</param>
        /// <returns>Item1 is weight of item, Item2 is the price</returns>
        Tuple<decimal, decimal> GetPricePerWeight(string name);

        /// <summary>
        /// Registers bulk discount. The only bulk discount per item is allowed
        /// </summary>
        /// <param name="bulk">Bulk discount</param>
        void SetBulkDiscount(Bulk bulk);

        /// <summary>
        /// Returns bulk discount for item or null if no discount for the item exists
        /// </summary>
        /// <returns>Bulk discount or null if not found</returns>
        Bulk GetBulkDiscount(string name);
    }
}
