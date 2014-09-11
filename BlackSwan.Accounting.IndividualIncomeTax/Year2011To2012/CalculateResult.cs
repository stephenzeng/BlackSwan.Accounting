using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.IndividualIncomeTax.Year2011To2012
{
    public class CalculateResult
    {
        public decimal TaxableIncome { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal MedicareLevy { get; set; }
        public decimal FloodLevy { get; set; }
        public decimal TaxOffset { get; set; }

        public decimal TaxAfterOffset
        {
            get { return IncomeTax > TaxOffset ? IncomeTax - TaxOffset : 0m; }
        }

        public decimal TotalTaxPayable
        {
            get { return TaxAfterOffset + MedicareLevy + FloodLevy; }
        }

        public decimal NetIncome
        {
            get { return TaxableIncome - TotalTaxPayable; }
        }

        public decimal AverageTaxRate
        {
            get { return (TotalTaxPayable/TaxableIncome).RoundToRate(); }
        }
    }
}