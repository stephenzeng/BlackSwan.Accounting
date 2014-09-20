using System.Collections.Generic;
using System.ComponentModel;

namespace BlackSwan.Accounting.IndividualIncomeTax.Common
{
    public class TaxRatesBase
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Taxable income tax rates")]
        public IEnumerable<ThresholdRate> IncomeTaxRates { get; set; }
        public bool Enabled { get; set; }
    }
}