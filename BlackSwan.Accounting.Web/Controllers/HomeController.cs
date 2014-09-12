using System.Web.Mvc;

namespace BlackSwan.Accounting.Web.Controllers
{
    public class HomeController : RavenDbController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}