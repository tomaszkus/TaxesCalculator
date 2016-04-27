namespace TaxesCalculatorTests
{
    using Moq;

    using System;

    using NUnit.Framework;

    using TaxesCalculator.Calculation;
    using TaxesCalculator.Controllers;
    using TaxesCalculator.Models;

    [TestFixture]
    public class TaxControllerTest
    {
        private Mock<GenercTaxCalculator> flatTaskCalculator;

        private TaxesController controller;

        [SetUp]
        public void PerformMocksAndControllerInitialization()
        {
            flatTaskCalculator = new Mock<GenercTaxCalculator>();

            controller = new TaxesController(flatTaskCalculator.Object);
        }

        [Test]
        public void ShouldCallOnlyFlatTaxCalculator()
        {
            // given
            flatTaskCalculator.Setup(x => x.CalculateFor(It.IsAny<Money>(), It.IsAny<Boolean>())).Returns(new Money(20));

            // when
            var result = controller.GetTax(100);

            // then
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Amount, Is.EqualTo(20));
        }
    }
}
