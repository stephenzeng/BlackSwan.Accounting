using BlackSwan.Accounting.IndividualIncomeTax.Year2013To2014;
using NUnit.Framework;

namespace BlackSwan.Accounting.IndividualIncomeTax.Tests
{
    public class the_tax_calculator_2013_2014
    {
        [Test]
        public void calculate_income_tax_0_to_18200()
        {
            // arrange
            var calculator = new Calculator();

            // assert
            Assert.AreEqual(0m, calculator.CalculateIncomeTax(0m));
            Assert.AreEqual(0m, calculator.CalculateIncomeTax(1m));
            Assert.AreEqual(0m, calculator.CalculateIncomeTax(18119.5m));
            Assert.AreEqual(0m, calculator.CalculateIncomeTax(18200m));
        }

        [Test]
        public void calculate_income_tax_18201_to37000()
        {
            // arrange
            var calculator = new Calculator();

            // assert
            Assert.AreEqual(0.19m, calculator.CalculateIncomeTax(18201m));
            Assert.AreEqual(2242m, calculator.CalculateIncomeTax(30000m));
            Assert.AreEqual(3572m, calculator.CalculateIncomeTax(37000m));
        }

        [Test]
        public void calculate_income_tax_37001_to_80000()
        {
            // arrange
            var calculator = new Calculator();

            // assert
            Assert.AreEqual(3572.325m, calculator.CalculateIncomeTax(37001m));
            Assert.AreEqual(14297m, calculator.CalculateIncomeTax(70000m));
            Assert.AreEqual(17547m, calculator.CalculateIncomeTax(80000m));
        }

        [Test]
        public void calculate_income_tax_80001_to_180000()
        {
            // arrange
            var calculator = new Calculator();

            // assert
            Assert.AreEqual(17547.37m, calculator.CalculateIncomeTax(80001m));
            Assert.AreEqual(47147m, calculator.CalculateIncomeTax(160000m));
            Assert.AreEqual(54547m, calculator.CalculateIncomeTax(180000m));
        }

        [Test]
        public void calculate_income_tax_180001()
        {
            // arrange
            var calculator = new Calculator();

            // assert
            Assert.AreEqual(54547.45m, calculator.CalculateIncomeTax(180001m));
            Assert.AreEqual(423547m, calculator.CalculateIncomeTax(1000000m));
        }

        [Test]
        public void calculate_medicare_levy()
        {
            // arrange
            var calculator = new Calculator();

            // assert
            Assert.AreEqual(1500m, calculator.CalculateMedicareLevy(100000m));
        }

        [Test]
        public void calculate_tax()
        {
            // arrange
            var calculator = new Calculator();

            // assert
            Assert.AreEqual(438547, calculator.Calculate(1000000m));
            Assert.AreEqual(4747m, calculator.Calculate(40000m));
        }

        [Test]
        public void calculate_low_income_tax_offset()
        {
            // arrange
            var calculator = new Calculator();

            // assert
            Assert.AreEqual(445m, calculator.CalculateLowIncomeTaxOffset(30000m));
            Assert.AreEqual(445m, calculator.CalculateLowIncomeTaxOffset(37000m));
            Assert.AreEqual(249.85m, calculator.CalculateLowIncomeTaxOffset(50010m));
            Assert.AreEqual(0.01m, calculator.CalculateLowIncomeTaxOffset(66666m));
            Assert.AreEqual(0m, calculator.CalculateLowIncomeTaxOffset(70000m));
        }
    }
}