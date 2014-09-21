using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.Web.Models
{
    public class TaxCalculateViewModel
    {
        [Required]
        public int TaxableIncome { get; set; }
        public int SelectedYear { get; set; }
        public CalculateResultBase Result { get; set; }
    }
}