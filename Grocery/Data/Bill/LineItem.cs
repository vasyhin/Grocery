using Grocery.Data.Catalog;

namespace Grocery.Data.Bill
{
    /// <summary>
    /// Represents bill line item
    /// </summary>
    public class LineItem
    {
        /// <summary>
        /// Item
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// Item quantity
        /// </summary>
        public decimal Quantity { get; set; }
    }
}
