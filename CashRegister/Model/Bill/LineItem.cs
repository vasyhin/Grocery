using System;
using CashRegister.Model.Catalog;

namespace CashRegister.Model.Bill
{
    /// <inheritdoc />
    /// <summary>
    /// Represents bill's line item
    /// </summary>
    public class LineItem: Item
    {
        /// <summary>
        /// Item quantity
        /// </summary>
        public decimal Quantity { get; set; }

        public LineItem(string name, decimal price, decimal quantity)
            : base(name, price)
        {
            if (quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity should be positive");

            Quantity = quantity;
        }
    }
}
