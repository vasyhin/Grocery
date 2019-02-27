namespace Grocery.Data.Catalog
{
    /// <summary>
    /// Defines the cost for items which are sold by weight (i.e., Apples)
    /// </summary>
    public class PricePerWeight
    {
        /// <summary>
        /// The item
        /// </summary>
        public Item Item { get; set; }

        // TODO: to discuss - it worth either to have pound/kg switch in the model. Or if it's always "per pound" then PricePerItem can be used instead
        /// <summary>
        /// Item's weight which is priced (i.e., per pound)
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// Item's cost per amount specified in Weight
        /// </summary>
        public decimal Price { get; set; }
    }
}
