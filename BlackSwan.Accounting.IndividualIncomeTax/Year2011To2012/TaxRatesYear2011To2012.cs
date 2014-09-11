using System.Collections.Generic;
using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.IndividualIncomeTax.Year2011To2012
{
    public class TaxRatesYear2011To2012
    {
        public TaxRatesYear2011To2012()
        {
            IncomeTaxRates = new[]
            {
                new ThresholdRate {StartAmount = 0m, Rate = 0m},
                new ThresholdRate {StartAmount = 6000m, Rate = 0.15m},
                new ThresholdRate {StartAmount = 37000m, Rate = 0.3m},
                new ThresholdRate {StartAmount = 80000m, Rate = 0.37m},
                new ThresholdRate {StartAmount = 180000m, Rate = 0.45m},
            };

            MedicareLevyRates = new[]
            {
                new ThresholdRate {StartAmount = 0m, Rate = 0m},
                new ThresholdRate {StartAmount = 19404m, Rate = 0.1m},
                new ThresholdRate {StartAmount = 22828m, Rate = 0.015m},
            };

            FloodLevyRates = new[]
            {
                new ThresholdRate {StartAmount = 0m, Rate = 0m},
                new ThresholdRate {StartAmount = 50000m, Rate = 0.005m},
                new ThresholdRate {StartAmount = 100000m, Rate = 0.01m},
            };

            LowIncomeTaxOffsetRate = new LowIncomeTaxOffsetRate
            {
                Rate = 0.04m,
                StartAmount = 30000m,
                FullTaxOffsetAmount = 1500m,
            };
        }

        public IEnumerable<ThresholdRate> IncomeTaxRates { get; set; }
        public IEnumerable<ThresholdRate> MedicareLevyRates { get; set; }
        public IEnumerable<ThresholdRate> FloodLevyRates { get; set; }
        public LowIncomeTaxOffsetRate LowIncomeTaxOffsetRate { get; set; }
    }
}