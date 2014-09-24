using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.IndividualIncomeTax
{
    public class CalculateResult2014 : CalculateResultBase
    {
        public override string DisplayName
        {
            get { return "CalculateResult2014"; }
        }

        [DisplayName("Taxable income")]
        [DataType(DataType.Currency)]
        public decimal TaxableIncome { get; set; }

        [DisplayName("Income tax")]
        [DataType(DataType.Currency)]
        public decimal IncomeTax { get; set; }

        [DisplayName("Medicare levy")]
        [DataType(DataType.Currency)]
        public decimal MedicareLevy { get; set; }

        [DisplayName("Repaire levy")]
        [DataType(DataType.Currency)]
        public decimal RepairLevy { get; set; }

        [DisplayName("Tax offset")]
        [DataType(DataType.Currency)]
        public decimal TaxOffset { get; set; }

        [DisplayName("Tax after offset")]
        [DataType(DataType.Currency)]
        public decimal TaxAfterOffset
        {
            get { return IncomeTax > TaxOffset ? IncomeTax - TaxOffset : 0m; }
        }

        [DisplayName("Total tax payable")]
        [DataType(DataType.Currency)]
        public decimal TotalTaxPayable
        {
            get { return TaxAfterOffset + MedicareLevy + RepairLevy; }
        }

        [DisplayName("Net income after tax")]
        [DataType(DataType.Currency)]
        public decimal NetIncome
        {
            get { return TaxableIncome - TotalTaxPayable; }
        }

        [DisplayName("Average tax rate")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public decimal AverageTaxRate
        {
            get { return (TotalTaxPayable / TaxableIncome).RoundToRate(); }
        }
    }
}