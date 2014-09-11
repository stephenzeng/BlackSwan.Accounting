using System;
using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.IndividualIncomeTax.Year2011To2012
{
    public class Calculator
    {
        private readonly TaxRatesYear2011To2012 _rates;

        public Calculator()
        {
            _rates = new TaxRatesYear2011To2012();
        }

        public CalculateResult Calculate(decimal taxableIncome)
        {
            if (taxableIncome <= 0) throw new ArgumentException("Income must be larger than 0");

            var income = taxableIncome.RoundToCurrency();

            var result = new CalculateResult
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
            return taxableIncome.ThresholdRateCalculate(_rates.IncomeTaxRates).RoundToCurrency();
        }

        private decimal CalculateMedicareLevy(decimal taxableIncome)
        {
            return taxableIncome.ThresholdRateCalculate(_rates.MedicareLevyRates).RoundToCurrency();
        }

        private decimal CalculateFloodLevy(decimal taxableIncome)
        {
            return taxableIncome.ThresholdRateCalculate(_rates.FloodLevyRates).RoundToCurrency();
        }

        private decimal CalculateLowIncomeTaxOffset(decimal taxableIncome)
        {
            if (taxableIncome <= _rates.LowIncomeTaxOffsetRate.StartAmount)
                return _rates.LowIncomeTaxOffsetRate.FullTaxOffsetAmount;

            var offset = _rates.LowIncomeTaxOffsetRate.FullTaxOffsetAmount -
                         (taxableIncome - _rates.LowIncomeTaxOffsetRate.StartAmount)*_rates.LowIncomeTaxOffsetRate.Rate;

            return offset > 0m ? offset.RoundToCurrency() : 0m;
        }
    }
}
