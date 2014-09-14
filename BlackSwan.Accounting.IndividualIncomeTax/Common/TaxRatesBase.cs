using System.Collections.Generic;

namespace BlackSwan.Accounting.IndividualIncomeTax.Common
{
    public class TaxRatesBase
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ThresholdRate> IncomeTaxRates { get; set; }
    }
}