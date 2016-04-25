namespace TaxesCalculator.Controllers
{
    using System.Web.Http;

    using TaxesCalculator.Calculation;
    using TaxesCalculator.Models;

    public class TaxesController : ApiController
    {
        private readonly FlatTaxCalculator flatTaxCalculator;

        private readonly ProgressiveTaxCalculator progressiveTaxCalculator;

        public TaxesController(FlatTaxCalculator flatTaxCalculator, ProgressiveTaxCalculator progressiveTaxCalculator)
        {
            this.flatTaxCalculator = flatTaxCalculator;
            this.progressiveTaxCalculator = progressiveTaxCalculator;
        }

        [Route("api/taxes/{incomes}")]
        [HttpGet]
        public Money GetTax(decimal incomes, bool flat = true)
        {
            if (flat == false)
            {
                return progressiveTaxCalculator.CalculateFor(new Money(incomes));
            }

            return flatTaxCalculator.CalculateFor(new Money(incomes));
        }
    }
}