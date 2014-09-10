using System.Collections.Generic;
using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.IndividualIncomeTax.Year2014To2015
{
    public class TaxRates
    {
        public TaxRates()
        {
            IncomeTaxRates = new[]
                {
                    new ThresholdRate {StartAmount = 0m, Rate = 0m},
                    new ThresholdRate {StartAmount = 18200m, Rate = 0.19m},
                    new ThresholdRate {StartAmount = 37000m, Rate = 0.325m},
                    new ThresholdRate {StartAmount = 80000m, Rate = 0.37m},
                    new ThresholdRate {StartAmount = 180000m, Rate = 0.45m},
                };

            MedicareLevyRates = new[]
                {
                    new ThresholdRate {StartAmount = 0m, Rate = 0m},
                    new ThresholdRate {StartAmount = 20542m, Rate = 0.1m},
                    new ThresholdRate {StartAmount = 24167m, Rate = 0.02m},
                };

            BudgetRepairLevyRate = new TemporaryBudgetRepairLevyRate
                {
                    Rate = 0.02m,
                    StartAmount = 180000,
                };

            LowIncomeTaxOffsetRate = new LowIncomeTaxOffsetRate
                {
                    Rate = 0.015m,
                    StartAmount = 37000m,
                    FullTaxOffsetAmount = 445m,
                };
        }

        public IEnumerable<ThresholdRate> IncomeTaxRates { get; set; }
        public IEnumerable<ThresholdRate> MedicareLevyRates { get; set; }
        public TemporaryBudgetRepairLevyRate BudgetRepairLevyRate { get; set; }
        public LowIncomeTaxOffsetRate LowIncomeTaxOffsetRate { get; set; } 
    }
}