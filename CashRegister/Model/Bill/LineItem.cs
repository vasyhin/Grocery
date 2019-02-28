using System;
using CashRegister.Model.Catalog;

namespace CashRegister.Model.Bill
{
    /// <summary>
    /// Represents bill line item
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
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quentity shold be positive");

            Quantity = quantity;
        }
    }
}
