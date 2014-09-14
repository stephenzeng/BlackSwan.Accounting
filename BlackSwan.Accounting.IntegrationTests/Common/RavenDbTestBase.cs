using System;
using BlackSwan.Accounting.Common;
using BlackSwan.Accounting.Common.Indexes;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace BlackSwan.Accounting.IntegrationTests.Common
{
    public abstract class RavenDbTestBase : IDisposable
    {
        protected RavenDbTestBase()
        {
            DocumentStore = new EmbeddableDocumentStore {RunInMemory = true};
            DocumentStore.Initialize();

            IndexCreation.CreateIndexes(typeof(TaxRatesBaseIndex).Assembly, DocumentStore);

            DocumentStore.RegisterListener(new NoStaleQueriesAllowed());
        }

        public EmbeddableDocumentStore DocumentStore { get; private set; }
        
        public void Dispose()
        {
            if (DocumentStore != null) DocumentStore.Dispose();
        }
    }
}