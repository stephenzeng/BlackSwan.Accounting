using System;

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
    }
}