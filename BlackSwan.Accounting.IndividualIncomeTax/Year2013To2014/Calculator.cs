using System.Linq;

namespace BlackSwan.Accounting.IndividualIncomeTax.Year2013To2014
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
            var taxOffset = CalculateLowIncomeTaxOffset(annualIncome);

            return incomeTax + medicareLevy - taxOffset;
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
