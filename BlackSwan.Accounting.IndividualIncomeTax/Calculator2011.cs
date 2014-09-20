using System;
using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.IndividualIncomeTax
{
    public class Calculator2011 : CalculatorBase<CalculateResult2011>
    {
        private readonly TaxRates2011 _taxRates2011;

        public Calculator2011(TaxRates2011 taxRates2011)
        {
            _taxRates2011 = taxRates2011;
        }

        public override CalculateResult2011 Calculate(decimal taxableIncome)
        {
            if (taxableIncome <= 0) throw new ArgumentException("Income must be larger than 0");

            var income = taxableIncome.RoundToCurrency();

            var result = new CalculateResult2011
                {
                    TaxableIncome = income,
                    IncomeTax = CalculateIncomeTax(income),
                    MedicareLevy = CalculateMedicareLevy(income),
                    FloodLevy = CalculateFloodLevy(income),
                    TaxOffset = CalculateLowIncomeTaxOffset(income)
                };

            return result;
        }

        private decimal CalculateIncomeTax(decimal taxableIncome)
        {
            return taxableIncome.ThresholdRateCalculate(_taxRates2011.IncomeTaxRates).RoundToCurrency();
        }

        private decimal CalculateMedicareLevy(decimal taxableIncome)
        {
            return taxableIncome.ThresholdRateCalculate(_taxRates2011.MedicareLevyRates).RoundToCurrency();
        }

        private decimal CalculateFloodLevy(decimal taxableIncome)
        {
            return taxableIncome.ThresholdRateCalculate(_taxRates2011.FloodLevyRates).RoundToCurrency();
        }

        private decimal CalculateLowIncomeTaxOffset(decimal taxableIncome)
        {
            if (taxableIncome <= _taxRates2011.LowIncomeTaxOffsetRate.StartAmount)
                return _taxRates2011.LowIncomeTaxOffsetRate.FullTaxOffsetAmount;

            var offset = _taxRates2011.LowIncomeTaxOffsetRate.FullTaxOffsetAmount -
                         (taxableIncome - _taxRates2011.LowIncomeTaxOffsetRate.StartAmount) * _taxRates2011.LowIncomeTaxOffsetRate.Rate;

            return offset > 0m ? offset.RoundToCurrency() : 0m;
        }
    }
}
