using System.Linq;
using System.Web.Mvc;
using BlackSwan.Accounting.Common.Indexes;
using BlackSwan.Accounting.IndividualIncomeTax.Common;
using Year2011 = BlackSwan.Accounting.IndividualIncomeTax.Year2011To2012;
using Year2014 = BlackSwan.Accounting.IndividualIncomeTax.Year2014To2015;
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