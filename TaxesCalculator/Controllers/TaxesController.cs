namespace TaxesCalculator.Controllers
{
    using System.Web.Http;

    using TaxesCalculator.Calculation;
    using TaxesCalculator.Models;

    public class TaxesController : ApiController
    {
        private readonly FlatTaxCalculator flatTaxCalculator;

        public TaxesController(FlatTaxCalculator flatTaxCalculator)
        {
            this.flatTaxCalculator = flatTaxCalculator;
        }

        [Route("api/taxes/{incomes}")]
        [HttpGet]
        public Money GetTax(decimal incomes, bool flat = true)
        {
            return flatTaxCalculator.CalculateFor(new Money(incomes));
        }
    }
}