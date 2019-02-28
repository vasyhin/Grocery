namespace CashRegister.Model.Catalog
{
    /// <summary>
    /// Represents priced grocery item (i.e., Cheerios or Apples)
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Item's cost
        /// </summary>
        public decimal Price { get; set; }

        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
