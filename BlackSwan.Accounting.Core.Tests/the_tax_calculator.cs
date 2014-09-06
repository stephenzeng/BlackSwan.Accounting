using NUnit.Framework;

namespace BlackSwan.Accounting.Core.Tests
{
    public class the_tax_calculator
    {
        [Test]
        public void calculate_from_0_to_18200()
        {
            // arrange
            var calculator = new TaxCalculator();

            // assert
            Assert.AreEqual(0m, calculator.CalculatorIncomeTax(0m));
            Assert.AreEqual(0m, calculator.CalculatorIncomeTax(1m));
            Assert.AreEqual(0m, calculator.CalculatorIncomeTax(18119.5m));
            Assert.AreEqual(0m, calculator.CalculatorIncomeTax(18200m));
        }

        [Test]
        public void calculate_from_18201_to37000()
        {
            // arrange
            var calculator = new TaxCalculator();

            // assert
            Assert.AreEqual(0.19m, calculator.CalculatorIncomeTax(18201m));
            Assert.AreEqual(2242m, calculator.CalculatorIncomeTax(30000m));
            Assert.AreEqual(3572m, calculator.CalculatorIncomeTax(37000m));
        }

        [Test]
        public void calculate_from_37001_to_80000()
        {
            // arrange
            var calculator = new TaxCalculator();

            // assert
            Assert.AreEqual(3572.325m, calculator.CalculatorIncomeTax(37001m));
            Assert.AreEqual(14297m, calculator.CalculatorIncomeTax(70000m));
            Assert.AreEqual(17547m, calculator.CalculatorIncomeTax(80000m));
        }

        [Test]
        public void calculate_from_80001_to_180000()
        {
            // arrange
            var calculator = new TaxCalculator();

            // assert
            Assert.AreEqual(17547.37m, calculator.CalculatorIncomeTax(80001m));
            Assert.AreEqual(47147m, calculator.CalculatorIncomeTax(160000m));
            Assert.AreEqual(54547m, calculator.CalculatorIncomeTax(180000m));
        }

        [Test]
        public void calculate_from_180001()
        {
            // arrange
            var calculator = new TaxCalculator();
            
            // assert
            Assert.AreEqual(54547.45m, calculator.CalculatorIncomeTax(180001m));
            Assert.AreEqual(423547m, calculator.CalculatorIncomeTax(1000000m));
        }
    }
}
