using System;
using BlackSwan.Accounting.IndividualIncomeTax.Year2014To2015;
using NUnit.Framework;

namespace BlackSwan.Accounting.IndividualIncomeTax.Tests
{
    public class the_tax_calculator_2014_2015
    {
        [Test]
        public void throw_exception_if_not_larger_than_0()
        {
            // arrange
            var calculator = new Calculator();

            // assert
            Assert.Catch<ArgumentException>(() => calculator.Calculate(-0.1m));
            Assert.Catch<ArgumentException>(() => calculator.Calculate(0m));
        }

        [Test]
        public void calculate_tax_18000()
        {
            // arrange
            var calculator = new Calculator();

            // act
            var result = calculator.Calculate(18000.006m);

            // assert
            Assert.AreEqual(18000.01m, result.TaxableIncome);
            Assert.AreEqual(0m, result.IncomeTax);
            Assert.AreEqual(0m, result.MedicareLevy);
            Assert.AreEqual(0m, result.RepairLevy);
            Assert.AreEqual(445m, result.TaxOffset);
            Assert.AreEqual(0m, result.TaxAfterOffset);
            Assert.AreEqual(0m, result.TotalTaxPayable);
            Assert.AreEqual(0m, result.AverageTaxRate);
        }

        [Test]
        public void calculate_tax_20542()
        {
            // arrange
            var calculator = new Calculator();

            // act
            var result = calculator.Calculate(20542.004m);

            // assert
            Assert.AreEqual(20542m, result.TaxableIncome);
            Assert.AreEqual(444.98m, result.IncomeTax);
            Assert.AreEqual(0m, result.MedicareLevy);
            Assert.AreEqual(0m, result.RepairLevy);
            Assert.AreEqual(445m, result.TaxOffset);
            Assert.AreEqual(0m, result.TaxAfterOffset);
            Assert.AreEqual(0m, result.TotalTaxPayable);
            Assert.AreEqual(0m, result.AverageTaxRate);
        }
    }
}
