using Grocery.Data.Catalog;
using Grocery.Services;
using System;

namespace Grocery.Discounts
{
    /// <summary>
    /// Represents bulk discount
    /// </summary>
    public class Bulk: Discount
    {
        /// <summary>
        /// 
        /// </summary>
        public Item Item { get; set; }
        public int AmountToBuy { get; set; }
        public int AmountToGetFree { get; set; }

        public override decimal ApplyDiscount(ICatalogService catalogService)
        {
            throw new NotImplementedException();
        }
    }
}
