using System.Linq;
using Raven.Client;

namespace BlackSwan.Accounting.IntegrationTests
{
    public static class Extensions
    {
        public static bool HasDatabase(this IDocumentStore documentStore, string databaseName)
        {
            return documentStore.DatabaseCommands.GetDatabaseNames(100).Contains(databaseName);
        }
    }
}