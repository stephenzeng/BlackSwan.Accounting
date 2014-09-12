using System.Linq;
using BlackSwan.Accounting.IndividualIncomeTax.Common;
using Year2014 = BlackSwan.Accounting.IndividualIncomeTax.Year2014To2015;
using Year2011 = BlackSwan.Accounting.IndividualIncomeTax.Year2011To2012;
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
            using (var session = DocumentStore.OpenSession())
            {
                Assert.IsNotNull(session.Load<Year2011.TaxRates>("TaxRates/2011"));
            }
        }

        private void insert_tax_rates_2014()
        {
            using (var session = DocumentStore.OpenSession())
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
            using (var session = DocumentStore.OpenSession())
            {
                Assert.IsNotNull(session.Load<Year2014.TaxRates>("TaxRates/2014"));
            }
        }

        private void query_tax_rates()
        {
            // assert
            using (var session = DocumentStore.OpenSession())
            {
                Assert.AreNotEqual(0, session.Query<Year2011.TaxRates>().Count());
                Assert.AreNotEqual(0, session.Query<Year2014.TaxRates>().Count());
            }
        }

        private void query_tax_rates_with_index()
        {
            // assert
            using (var session = DocumentStore.OpenSession())
            {
                var list = session.Query<TaxRatesBase, TaxRatesCountIndex>();
                Assert.AreNotEqual(0, list.Count());
            }
        }
    }
}
