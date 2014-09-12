using System.Collections.Generic;
using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.IndividualIncomeTax.Year2014To2015
{
    public class TaxRates : TaxRatesBase
    {
        public IEnumerable<ThresholdRate> MedicareLevyRates { get; set; }
        public IEnumerable<ThresholdRate> BudgetRepairLevyRates { get; set; }
        public LowIncomeTaxOffsetRate LowIncomeTaxOffsetRate { get; set; }
    }
}