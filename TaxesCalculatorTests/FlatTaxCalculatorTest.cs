namespace TaxesCalculatorTests
{
    using System;

    using NUnit.Framework;

    using TaxesCalculator.Calculation;
    using TaxesCalculator.Models;

    [TestFixture]
    public class FlatTaxCalculatorTest
    {
        private readonly GenercTaxCalculator calculator = new GenercTaxCalculator();

        [Test]
        public void ShouldThrowArgumentOutOfRangeExceptionForNegativeIncome()
        {
            // when
            Exception exception = null;
            try
            {
                calculator.CalculateFor(new Money(-1), true);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // then
            Assert.That(exception, Is.Not.Null);
            Assert.That(exception, Is.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(0, 0)]
        [TestCase(100, 20)]
        [TestCase(10000, 2000)]
        public void ShouldCalculateFlatTax(decimal incomes, decimal expectedTax)
        {
            // when
            var result = this.calculator.CalculateFor(new Money(incomes), true);

            // then
            Assert.That(result.Amount, Is.EqualTo(expectedTax));
        }
    }
}
