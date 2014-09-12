using System;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace BlackSwan.Accounting.IntegrationTests
{
    public abstract class RavenDbTestBase : IDisposable
    {
        protected RavenDbTestBase()
        {
            DocumentStore = new EmbeddableDocumentStore {RunInMemory = true};
            DocumentStore.Initialize();

            IndexCreation.CreateIndexes(typeof(TaxRatesCountIndex).Assembly, DocumentStore);

            DocumentStore.RegisterListener(new NoStaleQueriesAllowed());
        }

        public EmbeddableDocumentStore DocumentStore { get; private set; }
        
        public void Dispose()
        {
            if (DocumentStore != null) DocumentStore.Dispose();
        }
    }
}