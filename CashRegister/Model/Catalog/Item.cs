namespace CashRegister.Model.Catalog
{
    /// <summary>
    /// Represents item selling in CashRegister (i.e., Cheerios or Apples)
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Name of the item
        /// </summary>
        public string Name { get; }

        public Item(string name)
        {
            Name = name;
        }
    }
}
