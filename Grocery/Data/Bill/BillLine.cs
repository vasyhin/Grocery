using Grocery.Data.Catalog;

namespace Grocery.Data.Bill
{
    /// <summary>
    /// Represents bill line
    /// </summary>
    public class BillLine
    {
        /// <summary>
        /// Item
        /// </summary>
        public Item Item { get; set; }

        public decimal Quantity { get; set; }
    }
}
