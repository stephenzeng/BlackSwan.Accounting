using System.Collections.Generic;
using System.ComponentModel;
using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.IndividualIncomeTax.Year2011To2012
{
    public class TaxRates : TaxRatesBase
    {
        [DisplayName("Medicare levy rates")]
        public IEnumerable<ThresholdRate> MedicareLevyRates { get; set; }

        [DisplayName("Flood levy rates")]
        public IEnumerable<ThresholdRate> FloodLevyRates { get; set; }

        [DisplayName("Low income tax offset rate")]
        public LowIncomeTaxOffsetRate LowIncomeTaxOffsetRate { get; set; }
    }
}