using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartFlow.Common
{
    public class CurrencyData
    {
        public string CurrencyString { get; set; }
        public string Symbol { get; set; }
        public int CurrencyId { get; set; }
        public string Name { get; set; }
        public float ConversionRate { get; set; }
    }
}
