using System;
using System.Linq;
using BlackSwan.Accounting.IndividualIncomeTax.Common;
using BlackSwan.Accounting.IndividualIncomeTax.Year2011To2012;
using BlackSwan.Accounting.IndividualIncomeTax.Year2014To2015;
using Raven.Client.Document;

namespace RavenDbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertData();
            LoadData();

            Console.WriteLine("...");
            Console.ReadLine();
        }

        private static void LoadData()
        {
            var documentStore = new DocumentStore
                {
                    ConnectionStringName = "RavenDB",
                }.Initialize();

            using (var session = documentStore.OpenSession())
            {
                var taxRates2011To2012 = session.Query<TaxRatesYear2011To2012>().First();
                var taxRates2014To2015 = session.Query<TaxRatesYear2014To2015>().First();

                Console.WriteLine(taxRates2011To2012.LowIncomeTaxOffsetRate.FullTaxOffsetAmount);
                Console.WriteLine(taxRates2014To2015.LowIncomeTaxOffsetRate.FullTaxOffsetAmount);
            }
        }

        private static void InsertData()
        {
            var documentStore = new DocumentStore
                {
                    ConnectionStringName = "RavenDB",
                };

            documentStore.Initialize();

            using (var session = documentStore.OpenSession())
            {
                var taxRates2011To2012 = new TaxRatesYear2011To2012
                    {
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

                var taxRates2014To2015 = new TaxRatesYear2014To2015
                    {
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

                session.Store(taxRates2011To2012);
                session.Store(taxRates2014To2015);
                session.SaveChanges();
            }
        }
    }
}
