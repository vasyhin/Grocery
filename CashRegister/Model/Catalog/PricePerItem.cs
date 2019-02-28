namespace CashRegister.Model.Catalog
{
    /// <summary>
    /// Defines the cost for items which are sold by item (i.e., Cheerios)
    /// </summary>
    public class PricePerItem
    {
        /// <summary>
        /// The item
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// Item's cost
        /// </summary>
        public decimal Price { get; set; }
    }
}
