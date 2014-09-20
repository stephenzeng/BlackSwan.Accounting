using System.IO;
using BlackSwan.Accounting.IndividualIncomeTax;
using BlackSwan.Accounting.IndividualIncomeTax.Common;
using Raven.Client;

namespace BlackSwan.Accounting.Web.Helpers
{
    public class CalculatorHelper
    {
        private readonly IDocumentSession _session;

        public CalculatorHelper(IDocumentSession session)
        {
            _session = session;
        }

        public CalculateResultBase GetCalculator(int year, decimal income)
        {
            switch (year)
            {
                case 2011:
                    var taxRates2011 = _session.Load<TaxRates2011>(year);
                    return new Calculator2011(taxRates2011).Calculate(income);
                case 2014:
                    var taxRates2014 = _session.Load<TaxRates2014>(year);
                    return new Calculator2014(taxRates2014).Calculate(income);
            }

            throw new InvalidDataException("Year does not exist");
        }
    }
}