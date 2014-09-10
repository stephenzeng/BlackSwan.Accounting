using System.Collections.Generic;
using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.IndividualIncomeTax.Year2013To2014
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

            MedicareLevyRate = 0.015m;

            LowIncomeTaxOffsetRate = new LowIncomeTaxOffsetRate
                {
                    Rate = 0.015m,
                    StartAmount = 37000m,
                    FullTaxOffsetAmount = 445m,
                };
        }

        public IEnumerable<IncomeTaxRate> IncomeTaxRates { get; set; }
        public decimal MedicareLevyRate { get; set; }
        public LowIncomeTaxOffsetRate LowIncomeTaxOffsetRate { get; set; }
    }
}