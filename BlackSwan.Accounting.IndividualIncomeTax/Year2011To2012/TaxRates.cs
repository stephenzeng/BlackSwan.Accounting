using System.Collections.Generic;
using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.IndividualIncomeTax.Year2011To2012
{
    public class TaxRates : TaxRatesBase
    {
        public IEnumerable<ThresholdRate> MedicareLevyRates { get; set; }
        public IEnumerable<ThresholdRate> FloodLevyRates { get; set; }
        public LowIncomeTaxOffsetRate LowIncomeTaxOffsetRate { get; set; }
    }
}