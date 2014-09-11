using System;
using System.Linq;
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
            var tax = 0m;
            var income = taxableIncome;

            foreach (var rate in _rates.IncomeTaxRates.Where(r => r.StartAmount <= taxableIncome).OrderByDescending(r => r.StartAmount))
            {
                tax += (income - rate.StartAmount)*rate.Rate;
                income = rate.StartAmount;
            }

            return tax.RoundToCurrency();
        }

        private decimal CalculateMedicareLevy(decimal taxableIncome)
        {
            var levy = 0m;
            var income = taxableIncome;

            foreach (var rate in _rates.MedicareLevyRates.Where(r => r.StartAmount <= taxableIncome).OrderByDescending(r => r.StartAmount))
            {
                levy += (income - rate.StartAmount) * rate.Rate;
                income = rate.StartAmount;
            }

            return levy.RoundToCurrency();
        }

        private decimal CalculateTemporaryBudgetRepairLevy(decimal taxableIncome)
        {
            if (taxableIncome <= _rates.BudgetRepairLevyRate.StartAmount) return 0m;

            var ley = (taxableIncome - _rates.BudgetRepairLevyRate.StartAmount)*_rates.BudgetRepairLevyRate.Rate;

            return ley.RoundToCurrency();
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
