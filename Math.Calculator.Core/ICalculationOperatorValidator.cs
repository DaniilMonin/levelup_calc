namespace Math.Calculator.Core
{
    public interface ICalculationOperatorValidator<TItem>
        where TItem : class, ICalculationOperator
    {
        string Id { get; }

        string DisplayName { get; }

        ICalculationValidationResult ValidateOperator(TItem calculationOperator);
    }
}