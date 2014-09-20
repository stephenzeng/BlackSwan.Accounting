using System.Linq;
using BlackSwan.Accounting.Common.Indexes;
using BlackSwan.Accounting.IndividualIncomeTax;
using BlackSwan.Accounting.IndividualIncomeTax.Common;
using BlackSwan.Accounting.IntegrationTests.Common;
using NUnit.Framework;

namespace BlackSwan.Accounting.IntegrationTests
{
    public class ravendb_test : RavenDbTestBase
    {
        [Test]
        public void execute_tests()
        {
            insert_tax_rates_2011();
            insert_tax_rates_2014();
            query_tax_rates();
            query_tax_rates_with_index();
        }

       private void insert_tax_rates_2011()
        {
            using (var session = DocumentStore.OpenSession())
            {
                session.Store(TaxRatesConfiguration.TaxRates2011);
                session.SaveChanges();
            }

            // assert
            using (var session = DocumentStore.OpenSession())
            {
                Assert.IsNotNull(session.Load<TaxRates2011>(2011));
            }
        }

        private void insert_tax_rates_2014()
        {
            using (var session = DocumentStore.OpenSession())
            {
                session.Store(TaxRatesConfiguration.TaxRates2014);
                session.SaveChanges();
            }

            // assert
            using (var session = DocumentStore.OpenSession())
            {
                Assert.IsNotNull(session.Load<TaxRates2014>(2014));
            }
        }

        private void query_tax_rates()
        {
            // assert
            using (var session = DocumentStore.OpenSession())
            {
                Assert.AreNotEqual(0, session.Query<TaxRates2011>().Count());
                Assert.AreNotEqual(0, session.Query<TaxRates2014>().Count());
            }
        }

        private void query_tax_rates_with_index()
        {
            // assert
            using (var session = DocumentStore.OpenSession())
            {
                var list = session.Query<TaxRatesBase, TaxRatesBaseIndex>();
                Assert.AreEqual(2, list.Count());

                var rate2011 = session.Query<TaxRatesBase, TaxRatesBaseIndex>()
                    .Single(r => r.Year == 2011);
                Assert.IsNotNull(rate2011);
            }
        }
    }
}
