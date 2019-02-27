using Grocery.Data.Catalog;

namespace Grocery.Discounts
{
    /// <summary>
    /// Represents bulk discount
    /// </summary>
    public class BulkDiscount
    {
        /// <summary>
        /// Discounted item
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// The number of items to be purchased to apply this discount
        /// </summary>
        public int BulkItemsCount { get; set; }

        /// <summary>
        /// The number of items to get free
        /// </summary>
        public int BonusItemsCount { get; set; }
    }
}
