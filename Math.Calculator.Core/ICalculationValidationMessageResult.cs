namespace Math.Calculator.Core
{
    public interface ICalculationValidationMessageResult
    {
        string Property { get; }

        string Message { get; }
    }
}