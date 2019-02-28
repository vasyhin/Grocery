namespace Grocery.Data.Catalog
{
    /// <summary>
    /// Represents item selling in grocery (i.e., Boxes of Cheerios or Apples)
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
