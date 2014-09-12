using System.Linq;
using Raven.Client.Indexes;

namespace BlackSwan.Accounting.IntegrationTests
{
    public class TaxRatesCountIndex : AbstractMultiMapIndexCreationTask
    {
        public TaxRatesCountIndex()
        {
            AddMap<IndividualIncomeTax.Year2014To2015.TaxRates>(rates => rates.Select(r => new {r.Id}));
            AddMap<IndividualIncomeTax.Year2011To2012.TaxRates>(rates => rates.Select(r => new {r.Id}));
        }
    }
}