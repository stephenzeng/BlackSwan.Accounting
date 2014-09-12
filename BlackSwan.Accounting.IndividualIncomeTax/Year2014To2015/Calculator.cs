using System;
using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.IndividualIncomeTax.Year2014To2015
{
    public class Calculator
    {
        private readonly TaxRates _rates;

        public Calculator()
        {
            _rates = new TaxRates();
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
                    RepairLevy = CalculateTemporaryBudgetRepairLevy(income),
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

        private decimal CalculateTemporaryBudgetRepairLevy(decimal taxableIncome)
        {
            return taxableIncome.ThresholdRateCalculate(_rates.BudgetRepairLevyRates).RoundToCurrency();
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
