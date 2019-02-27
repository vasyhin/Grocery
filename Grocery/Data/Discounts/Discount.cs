using Grocery.Services;

namespace Grocery.Discounts
{
    /// <summary>
    /// Represents a discount
    /// </summary>
    public abstract class Discount
    {
        public abstract decimal ApplyDiscount(ICatalogService catalogService);
    }
}
