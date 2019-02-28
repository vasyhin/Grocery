using System;
using System.Collections.Generic;

namespace CashRegister.Model.Bill
{
    /// <summary>
    /// Represents the bill
    /// </summary>
    public class Bill
    {
        /// <summary>
        /// List of bill lines
        /// </summary>
        public IList<LineItem> LineItems { get; }

        public Bill(IList<LineItem> lineItems)
        {
            if (lineItems == null || lineItems.Count == 0)
            {
                throw new ArgumentException(nameof(lineItems), "Unable to create bill without line items");
            }

            LineItems = lineItems;
        }
    }
}
