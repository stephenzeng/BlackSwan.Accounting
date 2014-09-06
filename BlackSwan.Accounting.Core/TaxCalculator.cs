using System.Linq;

namespace BlackSwan.Accounting.Core
{
    public class TaxCalculator
    {
        public decimal CalculatorIncomeTax(decimal annaulIncome)
        {
            var rates = new[]
                {
                    new TaxRate {StartAmount = 0m, Rate = 0m},
                    new TaxRate {StartAmount = 18200m, Rate = 0.19m},
                    new TaxRate {StartAmount = 37000m, Rate = 0.325m},
                    new TaxRate {StartAmount = 80000m, Rate = 0.37m},
                    new TaxRate {StartAmount = 180000m, Rate = 0.45m},
                };

            var tax = 0m;
            var income = annaulIncome;

            foreach (var rate in rates.Where(r => r.StartAmount <= annaulIncome).OrderByDescending(r => r.StartAmount))
            {
                tax += (income - rate.StartAmount)*rate.Rate;
                income = rate.StartAmount;
            }

            return tax;
        }
    }
}
