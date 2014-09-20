namespace BlackSwan.Accounting.IndividualIncomeTax.Common
{
    public abstract class CalculatorBase<TResult> where TResult:CalculateResultBase
    {
        public int Id { get; set; }
        public abstract TResult Calculate(decimal income);
    }
}