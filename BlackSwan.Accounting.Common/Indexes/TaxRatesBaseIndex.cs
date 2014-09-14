using System.Linq;
using Year2011 = BlackSwan.Accounting.IndividualIncomeTax.Year2011To2012;
using Year2014 = BlackSwan.Accounting.IndividualIncomeTax.Year2014To2015;
using Raven.Client.Indexes;

namespace BlackSwan.Accounting.Common.Indexes
{
    public class TaxRatesBaseIndex : AbstractMultiMapIndexCreationTask
    {
        public TaxRatesBaseIndex()
        {
            AddMap<Year2011.TaxRates>(rates => rates.Select(r => new {r.Id, r.Year}));
            AddMap<Year2014.TaxRates>(rates => rates.Select(r => new {r.Id, r.Year}));
        }
    }
}