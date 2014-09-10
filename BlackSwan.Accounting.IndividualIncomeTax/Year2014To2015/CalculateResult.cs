using System;

namespace BlackSwan.Accounting.IndividualIncomeTax.Year2014To2015
{
    public class CalculateResult
    {
        public decimal TaxableIncome { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal MedicareLevy { get; set; }
        public decimal RepairLevy { get; set; }
        public decimal TaxOffset { get; set; }

        public decimal TaxAfterOffset
        {
            get { return IncomeTax > TaxOffset ? IncomeTax - TaxOffset : 0m; }
        }

        public decimal TotalTaxPayable
        {
            get { return TaxAfterOffset + MedicareLevy + RepairLevy; }
        }

        public decimal NetIncome
        {
            get { return TaxableIncome - TotalTaxPayable; }
        }

        public decimal AverageTaxRate
        {
            get { return Math.Round(TotalTaxPayable/TaxableIncome, 4, MidpointRounding.AwayFromZero); }
        }
    }
}