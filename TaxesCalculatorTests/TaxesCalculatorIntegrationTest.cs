namespace TaxesCalculatorTests
{
    using Microsoft.Owin.Testing;

    using Newtonsoft.Json;

    using NUnit.Framework;

    using TaxesCalculator;
    using TaxesCalculator.Models;

    [TestFixture]
    public class TaxesCalculatorIntegrationTest
    {
        private TestServer server;

        [TestFixtureSetUp]
        public void FixtureInit()
        {
            server = TestServer.Create<Startup>();
        }

        [TestFixtureTearDown]
        public void FixtureDispose()
        {
            server.Dispose();
        }

        [Test]
        public void ShouldReturnFlatTaxValueForGivenIncomes()
        {
            const decimal amount = 10000m;
            var response = server.HttpClient.GetAsync($"api/taxes/{amount}").Result;

            var result = response.Content.ReadAsStringAsync().Result;
            var money = JsonConvert.DeserializeObject<Money>(result);

            Assert.That(money, Is.Not.Null);
            Assert.That(money.Amount, Is.EqualTo(2000m));
        }
    }
}
