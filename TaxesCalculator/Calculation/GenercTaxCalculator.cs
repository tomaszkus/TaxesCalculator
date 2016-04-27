namespace TaxesCalculator.Calculation
{
    using System;

    using TaxesCalculator.Models;

    public class GenercTaxCalculator
    {
        public virtual Money CalculateFor(Money incomes, bool shouldBeProgresssive)
        {

            if (incomes.Amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return new Money(incomes.Amount * 0.2m);
        }
    }
}