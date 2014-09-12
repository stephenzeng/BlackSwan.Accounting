using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BlackSwan.Accounting.Common.Indexes;
using BlackSwan.Accounting.IndividualIncomeTax;
using BlackSwan.Accounting.IndividualIncomeTax.Common;
using BlackSwan.Accounting.Web.Controllers;
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
                HttpContext.Current.Items["CurrentRequestRavenSession"] = RavenDbController.DocumentStore.OpenSession();
            };

            EndRequest += (sender, args) =>
            {
                using (var session = (IDocumentSession) HttpContext.Current.Items["CurrentRequestRavenSession"])
                {
                    if (session == null) 
                        return;
                    
                    if (Server.GetLastError() != null) 
                        return;
                    
                    session.SaveChanges();
                }
            };
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            InitializeDocumentStore();
            RavenDbController.DocumentStore = DocumentStore;
            CreateDocumentIndexes();
            SetupDocumentStore();
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

        private static void CreateDocumentIndexes()
        {
            IndexCreation.CreateIndexesAsync(typeof(TaxRatesCountIndex).Assembly, DocumentStore);
        }

        private static void SetupDocumentStore()
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