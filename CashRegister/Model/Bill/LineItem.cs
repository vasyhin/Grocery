using System;
using CashRegister.Model.Catalog;

namespace CashRegister.Model.Bill
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

        public LineItem(Item item, decimal quantity)
        {
            if (quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quentity shold be positive");

            Quantity = quantity;
            Item = item ?? throw new ArgumentNullException("Item is required for Line Item");
        }
    }
}
