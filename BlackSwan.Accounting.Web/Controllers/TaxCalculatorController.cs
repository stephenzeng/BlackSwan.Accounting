using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BlackSwan.Accounting.Common.Indexes;
using BlackSwan.Accounting.IndividualIncomeTax;
using BlackSwan.Accounting.IndividualIncomeTax.Common;
using BlackSwan.Accounting.Web.Helpers;
using BlackSwan.Accounting.Web.Models;

namespace BlackSwan.Accounting.Web.Controllers
{
    public class TaxCalculatorController : ControllerBase
    {
        public ActionResult Index()
        {
            ViewBag.TaxRatesList = GetTaxRatesList();
            return View();
        }

        [HttpPost]
        public ActionResult Index(TaxCalculateViewModel viewModel)
        {
            var helper = new CalculatorHelper(DocumentSession);
            var result = helper.GetCalculator(viewModel.SelectedYear, viewModel.TaxableIncome);
            viewModel.Result = result;

            ViewBag.TaxRatesList = GetTaxRatesList();

            return View(viewModel);
        }

        private IEnumerable<SelectListItem> GetTaxRatesList()
        {
            var rates = DocumentSession.Query<TaxRatesBase, TaxRatesBaseIndex>()
                .OrderByDescending(r => r.Year)
                .ToList();

            return rates.Select(r => new SelectListItem { Text = r.Description, Value = r.Id.ToString() });
        }
    }
}