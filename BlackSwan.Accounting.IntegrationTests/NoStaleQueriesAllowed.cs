using Raven.Client;
using Raven.Client.Listeners;

namespace BlackSwan.Accounting.IntegrationTests
{
    public class NoStaleQueriesAllowed : IDocumentQueryListener
    {
        public void BeforeQueryExecuted(IDocumentQueryCustomization queryCustomization)
        {
            queryCustomization.WaitForNonStaleResults();
        }
    }
}