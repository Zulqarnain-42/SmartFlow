using DocumentFormat.OpenXml.VariantTypes;
using SmartFlow.Common;

namespace SmartFlow.Interface
{
    public interface ICurrencyService
    {
        CurrencyData DefaultCurrency { get; set; }
        void SetDefaultCurrency(CurrencyData currency);
    }
}
