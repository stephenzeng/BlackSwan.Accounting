using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BlackSwan.Accounting.Common.Indexes;
using BlackSwan.Accounting.IndividualIncomeTax;
using BlackSwan.Accounting.IndividualIncomeTax.Common;
using Raven.Abstractions.Extensions;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace BlackSwan.Accounting.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            BeginRequest += (sender, args) =>
            {
                HttpContext.Current.Items["CurrentRequestRavenSession"] = DocumentStore.OpenSession();
            };

            EndRequest += (sender, args) =>
            {
                using (var session = (IDocumentSession) HttpContext.Current.Items["CurrentRequestRavenSession"])
                {
                    if (session == null) return;

                    if (Server.GetLastError() != null) return;

                    session.SaveChanges();
                }
            };
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeDocumentStore();
            CreateIndexes();
            InitializeDocumentStoreData();
        }

        public static IDocumentStore DocumentStore { get; private set; }

        private static void InitializeDocumentStore()
        {
            if (DocumentStore != null) return;

            DocumentStore = new DocumentStore()
            {
                ConnectionStringName = "RavenDB"
            }.Initialize();
        }

        private static void CreateIndexes()
        {
            IndexCreation.CreateIndexes(typeof (TaxRatesCountIndex).Assembly, DocumentStore);
        }

        private static void InitializeDocumentStoreData()
        {
            using (var session = DocumentStore.OpenSession())
            {
                if (session.Query<TaxRatesBase, TaxRatesCountIndex>().Any()) return;
                TaxRatesConfiguration.TaxRates.ForEach(session.Store);
                session.SaveChanges();
            }
        }
    }
}
