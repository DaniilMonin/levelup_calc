namespace Math.Calculator.Core
{
    public interface ICalculationOperator
    {
        string DisplayName { get; }

        void Execute();
    }
}