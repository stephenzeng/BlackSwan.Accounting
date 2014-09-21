using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BlackSwan.Accounting.IndividualIncomeTax.Common;
using WebGrease;

namespace BlackSwan.Accounting.Web.Models
{
    public class TaxCalculateViewModel
    {
        [Required]
        [Display(Name = "taxable income")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Must be a number without digits")]
        public int TaxableIncome { get; set; }
        public int SelectedYear { get; set; }
        public CalculateResultBase Result { get; set; }
    }
}