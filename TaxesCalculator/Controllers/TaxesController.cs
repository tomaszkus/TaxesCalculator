namespace TaxesCalculator.Controllers
{
    using System.Web.Http;

    using TaxesCalculator.Calculation;
    using TaxesCalculator.Models;

    public class TaxesController : ApiController
    {
        private readonly GenercTaxCalculator genericTaxCalculator;

        public TaxesController(GenercTaxCalculator genercTaxCalculator)
        {
            this.genericTaxCalculator = genercTaxCalculator;
        }

        [Route("api/taxes/{incomes}")]
        [HttpGet]
        public Money GetTax(decimal incomes, bool flat = true)
        {
            return this.genericTaxCalculator.CalculateFor(new Money(incomes));
        }
    }
}