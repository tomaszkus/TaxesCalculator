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

        [Test]
        public void ShouldCalculateProgresssiveTax1_1()
        {
            var result = calculator.CalculateFor(new Money(5000), false);
            Assert.IsTrue(result.Amount == 750);
        }


        [Test]
        public void shouldCalculateProgresssiveTax1_2()
        {
            var result = calculator.CalculateFor(new Money(20000), false);
            Assert.IsTrue(result.Amount == 3000);
        }

        [Test]
        public void ShoudlCalculateProgresssiveTax1_3()
        {
            var result = calculator.CalculateFor(new Money(35000), false);
            Assert.IsTrue(result.Amount == 5250);
        }

        [Test]
        public void ShouldCalculateProgresssiveTax2_1()
        {
            var result = calculator.CalculateFor(new Money(45000), false);
            Assert.IsTrue(result.Amount == 7500);
        }


        [Test]
        public void shouldCalculateProgresssiveTax2_2()
        {
            var result = calculator.CalculateFor(new Money(55000), false);
            Assert.IsTrue(result.Amount == 10500);
        }

        [Test]
        public void ShoudlCalculateProgresssiveTax2_3()
        {
            var result = calculator.CalculateFor(new Money(65000), false);
            Assert.IsTrue(result.Amount == 13500);
        }
    }
}
