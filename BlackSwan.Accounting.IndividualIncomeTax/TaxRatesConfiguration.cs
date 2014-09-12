using System.Collections.Generic;
using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.IndividualIncomeTax
{
    public class TaxRatesConfiguration
    {
        public static IEnumerable<TaxRatesBase> TaxRates
        {
            get
            {
                yield return TaxRates2011;
                yield return TaxRates2014;
            }
        }

        public static Year2011To2012.TaxRates TaxRates2011
        {
            get
            {
                return new Year2011To2012.TaxRates()
                {
                    Id = "TaxRates/2011",
                    IncomeTaxRates = new[]
                    {
                        new ThresholdRate {StartAmount = 0m, Rate = 0m},
                        new ThresholdRate {StartAmount = 6000m, Rate = 0.15m},
                        new ThresholdRate {StartAmount = 37000m, Rate = 0.3m},
                        new ThresholdRate {StartAmount = 80000m, Rate = 0.37m},
                        new ThresholdRate {StartAmount = 180000m, Rate = 0.45m},
                    },
                    MedicareLevyRates = new[]
                    {
                        new ThresholdRate {StartAmount = 0m, Rate = 0m},
                        new ThresholdRate {StartAmount = 19404m, Rate = 0.1m},
                        new ThresholdRate {StartAmount = 22828m, Rate = 0.015m},
                    },
                    FloodLevyRates = new[]
                    {
                        new ThresholdRate {StartAmount = 0m, Rate = 0m},
                        new ThresholdRate {StartAmount = 50000m, Rate = 0.005m},
                        new ThresholdRate {StartAmount = 100000m, Rate = 0.01m},
                    },
                    LowIncomeTaxOffsetRate = new LowIncomeTaxOffsetRate
                    {
                        Rate = 0.04m,
                        StartAmount = 30000m,
                        FullTaxOffsetAmount = 1500m,
                    },
                };
            }
        }

        public static Year2014To2015.TaxRates TaxRates2014
        {
            get
            {
                return new Year2014To2015.TaxRates()
                {
                    Id = "TaxRates/2014",
                    IncomeTaxRates = new[]
                    {
                        new ThresholdRate {StartAmount = 0m, Rate = 0m},
                        new ThresholdRate {StartAmount = 18200m, Rate = 0.19m},
                        new ThresholdRate {StartAmount = 37000m, Rate = 0.325m},
                        new ThresholdRate {StartAmount = 80000m, Rate = 0.37m},
                        new ThresholdRate {StartAmount = 180000m, Rate = 0.45m},
                    },
                    MedicareLevyRates = new[]
                    {
                        new ThresholdRate {StartAmount = 0m, Rate = 0m},
                        new ThresholdRate {StartAmount = 20542m, Rate = 0.1m},
                        new ThresholdRate {StartAmount = 24167m, Rate = 0.02m},
                    },
                    BudgetRepairLevyRates = new[]
                    {
                        new ThresholdRate {StartAmount = 0m, Rate = 0m},
                        new ThresholdRate {StartAmount = 180000m, Rate = 0.02m},
                    },
                    LowIncomeTaxOffsetRate = new LowIncomeTaxOffsetRate
                    {
                        Rate = 0.015m,
                        StartAmount = 37000m,
                        FullTaxOffsetAmount = 445m,
                    },
                };
            }
        }
    }
}