using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.IndividualIncomeTax
{
    public class CalculateResult2014 : CalculateResultBase
    {
        public override string DisplayName
        {
            get { return "CalculateResult2014"; }
        }

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
            get { return (TotalTaxPayable / TaxableIncome).RoundToRate(); }
        }
    }
}