using System.Collections.Generic;

namespace BlackSwan.Accounting.Core
{
    public class TaxRatesFrom2014To2015
    {
        public TaxRatesFrom2014To2015()
        {
            TaxRates = new[]
                {
                    new TaxRate {StartAmount = 0m, Rate = 0m},
                    new TaxRate {StartAmount = 18200m, Rate = 0.19m},
                    new TaxRate {StartAmount = 37000m, Rate = 0.325m},
                    new TaxRate {StartAmount = 80000m, Rate = 0.37m},
                    new TaxRate {StartAmount = 180000m, Rate = 0.45m},
                };

            MedicareLevyRate = 0.02m;

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

        public IEnumerable<TaxRate> TaxRates { get; set; }
        public decimal MedicareLevyRate { get; set; }
        public TemporaryBudgetRepairLevyRate BudgetRepairLevyRate { get; set; }
        public LowIncomeTaxOffsetRate LowIncomeTaxOffsetRate { get; set; } 
    }
}