using System.Linq;
using Year2011 = BlackSwan.Accounting.IndividualIncomeTax.Year2011To2012;
using Year2014 = BlackSwan.Accounting.IndividualIncomeTax.Year2014To2015;
using Raven.Client.Indexes;

namespace BlackSwan.Accounting.Common.Indexes
{
    public class TaxRatesCountIndex : AbstractMultiMapIndexCreationTask
    {
        public TaxRatesCountIndex()
        {
            AddMap<Year2011.TaxRates>(rates => rates.Select(r => new {r.Id}));
            AddMap<Year2014.TaxRates>(rates => rates.Select(r => new {r.Id}));
        }
    }
}