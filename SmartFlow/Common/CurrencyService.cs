using SmartFlow.Interface;

namespace SmartFlow.Common
{
    public class CurrencyService : ICurrencyService
    {
        public CurrencyData DefaultCurrency { get; set; } = new CurrencyData
        {
            CurrencyId = 1,
            Symbol = "AED",
            CurrencyString = "AED",
            Name = "United Arab Emirates"
        };

        // Method to update the default currency
        public void SetDefaultCurrency(CurrencyData currency)
        {
            DefaultCurrency = currency;
        }
    }
}
