using System.Collections.Generic;

namespace BlackSwan.Accounting.IndividualIncomeTax.Common
{
    public class TaxRatesBase
    {
        public string Id { get; set; }
        public IEnumerable<ThresholdRate> IncomeTaxRates { get; set; }
    }
}