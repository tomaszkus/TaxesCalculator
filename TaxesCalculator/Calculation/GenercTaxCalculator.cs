namespace TaxesCalculator.Calculation
{
    using System;

    using TaxesCalculator.Models;

    public class GenercTaxCalculator
    {
        public virtual Money CalculateFor(Money incomes, bool shouldBeProgresssive)
        {


            if (shouldBeProgresssive)
            {
                if (incomes.Amount < 0)
                {
                    throw new ArgumentOutOfRangeException();;
                }

                return new Money(incomes.Amount * 0.2m);
            }
            else
            {
                if (incomes.Amount < 40000 && incomes.Amount >=0) {
                    return new Money(incomes.Amount * 0.15m);
                }
                else if (incomes.Amount > 40000 && incomes.Amount < 80000)
                {
                    return new Money(40000 * 0.15m + (incomes.Amount - 40000) * 0.30m);;}
                else if (incomes.Amount > 40000 && incomes.Amount < 80000)
                {
                    return new Money(40000 * 0.15m + (incomes.Amount - 40000) * 0.45m);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

        }
    }
}