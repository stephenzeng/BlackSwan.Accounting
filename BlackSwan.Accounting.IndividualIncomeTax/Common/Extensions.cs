using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackSwan.Accounting.IndividualIncomeTax.Common
{
    public static class Extensions
    {
        public static decimal RoundToCurrency(this decimal input)
        {
            return Math.Round(input, 2, MidpointRounding.AwayFromZero);
        }

        public static decimal RoundToRate(this decimal input)
        {
            return Math.Round(input, 4, MidpointRounding.AwayFromZero);
        }

        public static decimal ThresholdRateCalculate(this decimal input, IEnumerable<ThresholdRate> rates)
        {
            var output = 0m;
            var temp = input;

            foreach (var rate in rates.Where(r => r.StartAmount <= input).OrderByDescending(r => r.StartAmount))
            {
                output += (temp - rate.StartAmount) * rate.Rate;
                temp = rate.StartAmount;
            }

            return output;
        }
    }
}