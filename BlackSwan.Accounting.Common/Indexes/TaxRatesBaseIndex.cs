using System.Linq;
using BlackSwan.Accounting.IndividualIncomeTax;
using BlackSwan.Accounting.IndividualIncomeTax.Common;
using Raven.Client.Indexes;

namespace BlackSwan.Accounting.Common.Indexes
{
    public class TaxRatesBaseIndex : AbstractMultiMapIndexCreationTask<TaxRatesBase>
    {
        public TaxRatesBaseIndex()
        {
            AddMap<TaxRates2011>(rates => rates.Select(r => new {r.Id, r.Year}));
            AddMap<TaxRates2014>(rates => rates.Select(r => new {r.Id, r.Year}));
        }
    }
}