namespace TaxesCalculatorTests
{
    using Moq;

    using NUnit.Framework;

    using TaxesCalculator.Calculation;
    using TaxesCalculator.Controllers;
    using TaxesCalculator.Models;

    [TestFixture]
    public class TaxControllerTest
    {
        private Mock<FlatTaxCalculator> flatTaskCalculator;
        private Mock<ProgressiveTaxCalculator> progressiveTaskCalculator;

        private TaxesController controller;

        [SetUp]
        public void PerformMocksAndControllerInitialization()
        {
            flatTaskCalculator = new Mock<FlatTaxCalculator>();
            progressiveTaskCalculator = new Mock<ProgressiveTaxCalculator>();

            controller = new TaxesController(flatTaskCalculator.Object, progressiveTaskCalculator.Object);
        }

        [Test]
        public void ShouldCallOnlyFlatTaxCalculator()
        {
            // given
            flatTaskCalculator.Setup(x => x.CalculateFor(It.IsAny<Money>())).Returns(new Money(20));
            
            // when
            var result = controller.GetTax(100);

            // then
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Amount, Is.EqualTo(20));
        }

        [Test]
        public void ShouldCallOnlyProgressiveTaxCalculator()
        {
            // given
            progressiveTaskCalculator.Setup(x => x.CalculateFor(It.IsAny<Money>())).Returns(new Money(20));

            // when
            var result = controller.GetTax(100, false);

            // then
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Amount, Is.EqualTo(20));
        }
    }
}
