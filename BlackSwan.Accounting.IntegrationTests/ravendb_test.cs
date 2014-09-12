using System.Linq;
using BlackSwan.Accounting.IndividualIncomeTax.Common;
using Raven.Client.Indexes;
using Year2014 = BlackSwan.Accounting.IndividualIncomeTax.Year2014To2015;
using Year2011 = BlackSwan.Accounting.IndividualIncomeTax.Year2011To2012;
using NUnit.Framework;
using Raven.Client;
using Raven.Client.Document;

namespace BlackSwan.Accounting.IntegrationTests
{
    public class ravendb_test
    {
        private const string TestDatabaseName = "BlackSwan.Accounting.IntegrationTestsDB";
        private readonly IDocumentStore _testStore;

        public ravendb_test()
        {
            DeleteTestDatabase();
            _testStore = new DocumentStore()
            {
                ConnectionStringName = "TestDB"
            }.Initialize();

            IndexCreation.CreateIndexes(typeof (TaxRatesCountIndex).Assembly, _testStore);
        }

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
            using (var session = _testStore.OpenSession())
            {
                var taxRates = new Year2011.TaxRates()
                {
                    Id = "TaxRates/2011",
                    IncomeTaxRates = new[]
                    {
                        new ThresholdRate {StartAmount = 0m, Rate = 0m},
                        new ThresholdRate {StartAmount = 6000m, Rate = 0.15m},
                        new ThresholdRate {StartAmount = 37000m, Rate = 0.3m},
                        new ThresholdRate {StartAmount = 80000m, Rate = 0.37m},
                        new ThresholdRate {StartAmount = 180000m, Rate = 0.45m},
                    },
                    MedicareLevyRates = new[]
                    {
                        new ThresholdRate {StartAmount = 0m, Rate = 0m},
                        new ThresholdRate {StartAmount = 19404m, Rate = 0.1m},
                        new ThresholdRate {StartAmount = 22828m, Rate = 0.015m},
                    },
                    FloodLevyRates = new[]
                    {
                        new ThresholdRate {StartAmount = 0m, Rate = 0m},
                        new ThresholdRate {StartAmount = 50000m, Rate = 0.005m},
                        new ThresholdRate {StartAmount = 100000m, Rate = 0.01m},
                    },
                    LowIncomeTaxOffsetRate = new LowIncomeTaxOffsetRate
                    {
                        Rate = 0.04m,
                        StartAmount = 30000m,
                        FullTaxOffsetAmount = 1500m,
                    },
                };

                session.Store(taxRates);
                session.SaveChanges();
            }

            // assert
            using (var session = _testStore.OpenSession())
            {
                Assert.IsNotNull(session.Load<Year2011.TaxRates>("TaxRates/2011"));
            }
        }

        private void insert_tax_rates_2014()
        {
            using (var session = _testStore.OpenSession())
            {
                var taxRates = new Year2014.TaxRates()
                {
                    Id = "TaxRates/2014",
                    IncomeTaxRates = new[]
                    {
                        new ThresholdRate {StartAmount = 0m, Rate = 0m},
                        new ThresholdRate {StartAmount = 18200m, Rate = 0.19m},
                        new ThresholdRate {StartAmount = 37000m, Rate = 0.325m},
                        new ThresholdRate {StartAmount = 80000m, Rate = 0.37m},
                        new ThresholdRate {StartAmount = 180000m, Rate = 0.45m},
                    },
                    MedicareLevyRates = new[]
                    {
                        new ThresholdRate {StartAmount = 0m, Rate = 0m},
                        new ThresholdRate {StartAmount = 20542m, Rate = 0.1m},
                        new ThresholdRate {StartAmount = 24167m, Rate = 0.02m},
                    },
                    BudgetRepairLevyRates = new[]
                    {
                        new ThresholdRate {StartAmount = 0m, Rate = 0m},
                        new ThresholdRate {StartAmount = 180000m, Rate = 0.02m},
                    },
                    LowIncomeTaxOffsetRate = new LowIncomeTaxOffsetRate
                    {
                        Rate = 0.015m,
                        StartAmount = 37000m,
                        FullTaxOffsetAmount = 445m,
                    },
                };

                session.Store(taxRates);
                session.SaveChanges();
            }
            
            // assert
            using (var session = _testStore.OpenSession())
            {
                Assert.IsNotNull(session.Load<Year2014.TaxRates>("TaxRates/2014"));
            }
        }

        private void query_tax_rates()
        {
            using (var session = _testStore.OpenSession())
            {
                Assert.AreNotEqual(0, session.Query<Year2011.TaxRates>().Count());
                Assert.AreNotEqual(0, session.Query<Year2014.TaxRates>().Count());
            }
        }

        private void query_tax_rates_with_index()
        {
            using (var session = _testStore.OpenSession())
            {
                var list = session.Query<TaxRatesBase, TaxRatesCountIndex>();
                Assert.AreNotEqual(0, list.Count());
            }
        }

        private static void DeleteTestDatabase()
        {
            var store = new DocumentStore()
            {
                ConnectionStringName = "SystemDB"
            }.Initialize();

            if (store.HasDatabase(TestDatabaseName))
            {
                var relativeUrl = string.Format("/admin/databases/{0}", TestDatabaseName);
                var httpJsonRequest = store.AsyncDatabaseCommands.CreateRequest(relativeUrl, "DELETE");
                httpJsonRequest.ExecuteRequest();
            }
        }
    }

    public class TaxRatesCountIndex : AbstractMultiMapIndexCreationTask
    {
        public TaxRatesCountIndex()
        {
            AddMap<Year2014.TaxRates>(rates => rates.Select(r => new {r.Id}));
            AddMap<Year2011.TaxRates>(rates => rates.Select(r => new {r.Id}));
        }
    }
}
