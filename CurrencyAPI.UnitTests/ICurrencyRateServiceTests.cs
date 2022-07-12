using Xunit;

namespace CurrencyAPI.UnitTests
{
    public class ICurrencyRateServiceTests
    {

        public ICurrencyRateService currencyRateService { get; set; }

        public ICurrencyRateServiceTests()
        {
            currencyRateService = new CurrencyService();
        }

        [Fact]
        public void GetCurrenciesWithEnumTest()
        {
            var currency = currencyRateService.GetCurrencies(CurrencyEnums.USD);
            Assert.NotNull(currency);
        }
    }
}
