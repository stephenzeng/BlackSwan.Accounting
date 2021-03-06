﻿using System;
using NUnit.Framework;

namespace BlackSwan.Accounting.IndividualIncomeTax.Tests
{
    public class the_tax_calculator_2011_2012
    {
        private readonly Calculator2011 _calculator;

        public the_tax_calculator_2011_2012()
        {
            _calculator = new Calculator2011(TaxRatesConfiguration.TaxRates2011);
        }

        [Test]
        public void throw_exception_if_not_larger_than_0()
        {
            // assert
            Assert.Catch<ArgumentException>(() => _calculator.Calculate(-0.1m));
            Assert.Catch<ArgumentException>(() => _calculator.Calculate(0m));
        }

        [Test]
        public void calculate_tax_6000()
        {
            // act
            var result = _calculator.Calculate(6000.006m);

            // assert
            Assert.AreEqual(6000.01m, result.TaxableIncome);
            Assert.AreEqual(0m, result.IncomeTax);
            Assert.AreEqual(1500m, result.TaxOffset);
            Assert.AreEqual(0m, result.TaxAfterOffset);
            Assert.AreEqual(0m, result.MedicareLevy);
            Assert.AreEqual(0m, result.FloodLevy);
            Assert.AreEqual(0m, result.TotalTaxPayable);
            Assert.AreEqual(0m, result.AverageTaxRate);
        }

        [Test]
        public void calculate_tax_19404()
        {
            // act
            var result = _calculator.Calculate(19404.004m);

            // assert
            Assert.AreEqual(19404m, result.TaxableIncome);
            Assert.AreEqual(2010.6m, result.IncomeTax);
            Assert.AreEqual(1500m, result.TaxOffset);
            Assert.AreEqual(510.6m, result.TaxAfterOffset);
            Assert.AreEqual(0m, result.MedicareLevy);
            Assert.AreEqual(0m, result.FloodLevy);
            Assert.AreEqual(510.6m, result.TotalTaxPayable);
            Assert.AreEqual(0.0263m, result.AverageTaxRate);
        }

        [Test]
        public void calculate_tax_50000()
        {
            // act
            var result = _calculator.Calculate(50000m);

            // assert
            Assert.AreEqual(50000m, result.TaxableIncome);
            Assert.AreEqual(8550m, result.IncomeTax);
            Assert.AreEqual(700m, result.TaxOffset);
            Assert.AreEqual(7850m, result.TaxAfterOffset);
            Assert.AreEqual(749.98m, result.MedicareLevy);
            Assert.AreEqual(0m, result.FloodLevy);
            Assert.AreEqual(8599.98m, result.TotalTaxPayable);
            Assert.AreEqual(0.172m, result.AverageTaxRate);
        }

        [Test]
        public void calculate_tax_200000()
        {
            // act
            var result = _calculator.Calculate(200000m);

            // assert
            Assert.AreEqual(200000m, result.TaxableIncome);
            Assert.AreEqual(63550m, result.IncomeTax);
            Assert.AreEqual(0m, result.TaxOffset);
            Assert.AreEqual(63550m, result.TaxAfterOffset);
            Assert.AreEqual(2999.98m, result.MedicareLevy);
            Assert.AreEqual(1250m, result.FloodLevy);
            Assert.AreEqual(67799.98m, result.TotalTaxPayable);
            Assert.AreEqual(0.339m, result.AverageTaxRate);
        }
    }
}
