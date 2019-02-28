namespace CashRegister.Discounts
{
    /// <summary>
    /// Represents bulk discount
    /// </summary>
    public class BulkDiscount
    {
        /// <summary>
        /// Discounted item
        /// </summary>
        public string ItemName { get; }

        /// <summary>
        /// The number of items to be purchased to apply this discount
        /// </summary>
        public int BulkItemsCount { get; }

        /// <summary>
        /// The number of items to get free
        /// </summary>
        public int BonusItemsCount { get; }

        public BulkDiscount(string itemName, int bulkItemsCount, int bonusItemsCount)
        {
            ItemName = itemName;
            BulkItemsCount = bulkItemsCount;
            BonusItemsCount = bonusItemsCount;
        }
    }
}
