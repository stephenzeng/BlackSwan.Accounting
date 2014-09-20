using System;
using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.IndividualIncomeTax
{
    public class Calculator2014 : CalculatorBase<CalculateResult2014>
    {
        private readonly TaxRates2014 _taxRates2014;

        public Calculator2014(TaxRates2014 taxRates2014)
        {
            _taxRates2014 = taxRates2014;
        }

        public override CalculateResult2014 Calculate(decimal taxableIncome)
        {
            if (taxableIncome <= 0) throw new ArgumentException("Income must be larger than 0");

            var income = taxableIncome.RoundToCurrency();

            var result = new CalculateResult2014
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
            return taxableIncome.ThresholdRateCalculate(_taxRates2014.IncomeTaxRates).RoundToCurrency();
        }

        private decimal CalculateMedicareLevy(decimal taxableIncome)
        {
            return taxableIncome.ThresholdRateCalculate(_taxRates2014.MedicareLevyRates).RoundToCurrency();
        }

        private decimal CalculateTemporaryBudgetRepairLevy(decimal taxableIncome)
        {
            return taxableIncome.ThresholdRateCalculate(_taxRates2014.BudgetRepairLevyRates).RoundToCurrency();
        }

        private decimal CalculateLowIncomeTaxOffset(decimal taxableIncome)
        {
            if (taxableIncome <= _taxRates2014.LowIncomeTaxOffsetRate.StartAmount)
                return _taxRates2014.LowIncomeTaxOffsetRate.FullTaxOffsetAmount;

            var offset = _taxRates2014.LowIncomeTaxOffsetRate.FullTaxOffsetAmount -
                         (taxableIncome - _taxRates2014.LowIncomeTaxOffsetRate.StartAmount)*_taxRates2014.LowIncomeTaxOffsetRate.Rate;

            return offset > 0m ? offset.RoundToCurrency() : 0m;
        }
    }
}
