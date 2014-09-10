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
                    new IncomeTaxRate {StartAmount = 0m, Rate = 0m},
                    new IncomeTaxRate {StartAmount = 18200m, Rate = 0.19m},
                    new IncomeTaxRate {StartAmount = 37000m, Rate = 0.325m},
                    new IncomeTaxRate {StartAmount = 80000m, Rate = 0.37m},
                    new IncomeTaxRate {StartAmount = 180000m, Rate = 0.45m},
                };

            MedicareLevyRates = new[]
                {
                    new MedicareLevyRate {StartAmount = 0m, Rate = 0m},
                    new MedicareLevyRate {StartAmount = 20542m, Rate = 0.1m},
                    new MedicareLevyRate {StartAmount = 24167m, Rate = 0.02m},
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

        public IEnumerable<IncomeTaxRate> IncomeTaxRates { get; set; }
        public IEnumerable<MedicareLevyRate> MedicareLevyRates { get; set; }
        public TemporaryBudgetRepairLevyRate BudgetRepairLevyRate { get; set; }
        public LowIncomeTaxOffsetRate LowIncomeTaxOffsetRate { get; set; } 
    }
}