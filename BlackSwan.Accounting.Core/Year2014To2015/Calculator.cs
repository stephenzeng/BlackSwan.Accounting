using System.Linq;

namespace BlackSwan.Accounting.Core.Year2014To2015
{
    public class Calculator
    {
        private readonly TaxRates _rates;

        public Calculator()
        {
            _rates = new TaxRates();
        }

        public decimal Calculate(decimal annualIncome)
        {
            var incomeTax = CalculateIncomeTax(annualIncome);
            var medicareLevy = CalculateMedicareLevy(annualIncome);
            var repairLevy = CalculateTemporaryBudgetRepairLevy(annualIncome);
            var taxOffset = CalculateLowIncomeTaxOffset(annualIncome);

            return incomeTax + medicareLevy + repairLevy - taxOffset;
        }

        public decimal CalculateIncomeTax(decimal annaulIncome)
        {
            var tax = 0m;
            var income = annaulIncome;

            foreach (var rate in _rates.IncomeTaxRates.Where(r => r.StartAmount <= annaulIncome).OrderByDescending(r => r.StartAmount))
            {
                tax += (income - rate.StartAmount)*rate.Rate;
                income = rate.StartAmount;
            }

            return tax;
        }

        public decimal CalculateMedicareLevy(decimal annaulIncome)
        {
            return annaulIncome*_rates.MedicareLevyRate;
        }

        public decimal CalculateTemporaryBudgetRepairLevy(decimal annaulIncome)
        {
            if (annaulIncome <= _rates.BudgetRepairLevyRate.StartAmount) return 0m;

            return (annaulIncome - _rates.BudgetRepairLevyRate.StartAmount)*_rates.BudgetRepairLevyRate.Rate;
        }

        public decimal CalculateLowIncomeTaxOffset(decimal annaulIncome)
        {
            if (annaulIncome <= _rates.LowIncomeTaxOffsetRate.StartAmount)
                return _rates.LowIncomeTaxOffsetRate.FullTaxOffsetAmount;

            var offset = _rates.LowIncomeTaxOffsetRate.FullTaxOffsetAmount -
                         (annaulIncome - _rates.LowIncomeTaxOffsetRate.StartAmount)*_rates.LowIncomeTaxOffsetRate.Rate;

            return offset > 0m ? offset : 0m;
        }
    }
}
