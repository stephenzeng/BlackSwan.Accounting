using System.Linq;
using System.Web.Mvc;
using BlackSwan.Accounting.Common.Indexes;
using BlackSwan.Accounting.IndividualIncomeTax.Common;
using Raven.Client.Linq;

namespace BlackSwan.Accounting.Web.Controllers
{
    public class TaxRatesController : ControllerBase
    {
        public ActionResult Index()
        {
            var list = DocumentSession
                .Query<TaxRatesBase, TaxRatesBaseIndex>()
                .OrderByDescending(r => r.Id)
                .ToList();

            return View(list);
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}