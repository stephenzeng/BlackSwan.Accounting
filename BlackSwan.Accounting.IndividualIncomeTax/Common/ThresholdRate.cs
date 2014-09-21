using System.ComponentModel.DataAnnotations;

namespace BlackSwan.Accounting.IndividualIncomeTax.Common
{
    public class ThresholdRate
    {
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal StartAmount { get; set; }
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public decimal Rate { get; set; }
    }
}