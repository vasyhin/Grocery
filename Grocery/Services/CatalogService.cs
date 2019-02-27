using Grocery.Data.Catalog;
using Grocery.Discounts;
using System;
using System.Collections.Generic;

namespace Grocery.Services
{
    /// <summary>
    /// CatalogService
    /// </summary>
    public class CatalogService : ICatalogService
    {
        private Dictionary<string, PricePerItem> _pricesPerItem = new Dictionary<string, PricePerItem>();
        private Dictionary<string, BulkDiscount> _bulkDiscounts = new Dictionary<string, BulkDiscount>();

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

        /// <summary>
        /// Returns price of the item
        /// </summary>
        /// <param name="name">Item name</param>
        /// <returns>Price</returns>
        public decimal GetItemPrice(string name)
        {
            if (_pricesPerItem.ContainsKey(name))
                return _pricesPerItem[name].Price;

            throw new InvalidOperationException($"Can't find price for {name} item");
        }

        /// <summary>
        /// Registers price for the item
        /// </summary>
        /// <param name="item">Item</param>
        /// <param name="price">Price</param>
        public void RegisterItemPrice(Item item, decimal price)
        {
            if (item == null)
                throw new InvalidOperationException($"{nameof(item)} can't be null");

            _pricesPerItem[item.Name] = new PricePerItem { Item = item, Price = price };
        }

        /// <summary>
        /// Registers bulk discount
        /// </summary>
        /// <param name="bulk">Bulk discount</param>
        public void SetBulkDiscount(BulkDiscount bulk)
        {
            if (bulk == null)
                throw new InvalidOperationException($"{nameof(bulk)} can't be null");
            if (bulk.Item == null)
                throw new InvalidOperationException($"{nameof(bulk.Item)} can't be null");

            _bulkDiscounts[bulk.Item.Name] = bulk;
        }
    }
}
