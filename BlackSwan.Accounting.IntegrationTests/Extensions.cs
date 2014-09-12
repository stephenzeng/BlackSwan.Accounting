using System.Linq;
using Raven.Client;
using Raven.Client.Document;

namespace BlackSwan.Accounting.IntegrationTests
{
    public static class Extensions
    {
        public static bool HasDatabase(this IDocumentStore documentStore, string databaseName)
        {
            return documentStore.DatabaseCommands.GetDatabaseNames(100).Contains(databaseName);
        }

        public static void DeleteDatabase(string databaseName)
        {
            var store = new DocumentStore()
            {
                ConnectionStringName = "SystemDB"
            }.Initialize();

            if (store.HasDatabase(databaseName))
            {
                var relativeUrl = string.Format("/admin/databases/{0}", databaseName);
                var httpJsonRequest = store.AsyncDatabaseCommands.CreateRequest(relativeUrl, "DELETE");
                httpJsonRequest.ExecuteRequest();
            }
        }
    }
}