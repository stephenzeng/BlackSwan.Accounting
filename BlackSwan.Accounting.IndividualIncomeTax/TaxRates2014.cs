using System.Collections.Generic;
using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.IndividualIncomeTax
{
    public class TaxRates2014 : TaxRatesBase
    {
        public IEnumerable<ThresholdRate> MedicareLevyRates { get; set; }
        public IEnumerable<ThresholdRate> BudgetRepairLevyRates { get; set; }
        public LowIncomeTaxOffsetRate LowIncomeTaxOffsetRate { get; set; }
    }
}