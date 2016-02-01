namespace TaxesCalculator.Models
{
    public class Money
    {
        public Money(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; private set; }
    }
}