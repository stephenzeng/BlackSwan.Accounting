using System;
using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.IndividualIncomeTax.Year2014To2015
{
    public class Calculator
    {
        private readonly TaxRates _taxRates;

        public Calculator(TaxRates taxRates)
        {
            _taxRates = taxRates;
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
            return taxableIncome.ThresholdRateCalculate(_taxRates.IncomeTaxRates).RoundToCurrency();
        }

        private decimal CalculateMedicareLevy(decimal taxableIncome)
        {
            return taxableIncome.ThresholdRateCalculate(_taxRates.MedicareLevyRates).RoundToCurrency();
        }

        private decimal CalculateTemporaryBudgetRepairLevy(decimal taxableIncome)
        {
            return taxableIncome.ThresholdRateCalculate(_taxRates.BudgetRepairLevyRates).RoundToCurrency();
        }

        private decimal CalculateLowIncomeTaxOffset(decimal taxableIncome)
        {
            if (taxableIncome <= _taxRates.LowIncomeTaxOffsetRate.StartAmount)
                return _taxRates.LowIncomeTaxOffsetRate.FullTaxOffsetAmount;

            var offset = _taxRates.LowIncomeTaxOffsetRate.FullTaxOffsetAmount -
                         (taxableIncome - _taxRates.LowIncomeTaxOffsetRate.StartAmount)*_taxRates.LowIncomeTaxOffsetRate.Rate;

            return offset > 0m ? offset.RoundToCurrency() : 0m;
        }
    }
}
