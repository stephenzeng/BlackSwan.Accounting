using System.Web.Mvc;
using Raven.Client;

namespace BlackSwan.Accounting.Web.Controllers
{
    public abstract class RavenDbController : Controller
    {
        public static IDocumentStore DocumentStore { get; set; }

        public IDocumentSession RavenSession { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            RavenSession = (IDocumentSession)HttpContext.Items["CurrentRequestRavenSession"];
        }

        protected HttpStatusCodeResult HttpNotModified()
        {
            return new HttpStatusCodeResult(304);
        }
    }
}