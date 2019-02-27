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

        public BulkDiscount GetBulkDiscount(string name)
        {
            throw new NotImplementedException();
        }

        public decimal GetItemPrice(string name)
        {
            throw new NotImplementedException();
        }

        public void RegisterItemPrice(Item item, decimal price)
        {
            throw new NotImplementedException();
        }

        public void SetBulkDiscount(BulkDiscount bulk)
        {
            throw new NotImplementedException();
        }
    }
}
