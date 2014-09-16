using System.Linq;
using System.Web.Mvc;
using BlackSwan.Accounting.Common.Indexes;
using BlackSwan.Accounting.IndividualIncomeTax.Common;

namespace BlackSwan.Accounting.Web.Controllers
{
    public class TaxCalculatorController : ControllerBase
    {
        public ActionResult Index()
        {
            var rates = DocumentSession.Query<TaxRatesBase, TaxRatesBaseIndex>()
                .OrderByDescending(r => r.Year)
                .ToList();

            return View(rates);
        }
    }
}