using System.ComponentModel.DataAnnotations;

namespace BlackSwan.Accounting.IndividualIncomeTax.Common
{
    public class LowIncomeTaxOffsetRate
    {
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public decimal Rate { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal StartAmount { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal FullTaxOffsetAmount { get; set; }
    }
}