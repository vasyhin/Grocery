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
        private Dictionary<string, PricePerWeight> _pricesPerWeight = new Dictionary<string, PricePerWeight>();
        private Dictionary<string, Bulk> _bulkDiscounts = new Dictionary<string, Bulk>();

        public Bulk GetBulkDiscount(string name)
        {
            throw new NotImplementedException();
        }

        public decimal GetPricePerItem(string name)
        {
            throw new NotImplementedException();
        }

        public Tuple<decimal, decimal> GetPricePerWeight(string name)
        {
            throw new NotImplementedException();
        }

        public void RegisterPricePerItem(Item item, decimal price)
        {
            throw new NotImplementedException();
        }

        public void RegisterPricePerWeight(Item item, decimal weight, decimal price)
        {
            throw new NotImplementedException();
        }

        public void SetBulkDiscount(Bulk bulk)
        {
            throw new NotImplementedException();
        }
    }
}
