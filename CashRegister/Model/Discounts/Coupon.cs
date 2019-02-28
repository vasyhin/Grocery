namespace CashRegister.Model.Discounts
{
    /// <summary>
    /// Represents bulk discount
    /// </summary>
    public class Coupon
    {
        /// <summary>
        /// The total bill which should be reached to apply this coupon
        /// </summary>
        public decimal Threshold { get; }

        /// <summary>
        /// The amount of money to decrease the bill using this coupon
        /// </summary>
        public decimal MoneyOff{ get; }

        public Coupon(decimal threshold, decimal moneyOff)
        {
            // TODO: Validation & tests

            Threshold = threshold;
            MoneyOff = moneyOff;
        }
    }
}
