namespace Math.Calculator.Core
{
    public interface IHistoryItem
    {
        ICalculationOperator Operator { get; }
    }
}