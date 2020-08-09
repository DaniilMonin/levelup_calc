namespace Math.Calculator.Core
{
    public abstract class CalculationOperatorValidator : ICalculationOperatorValidator<ICalculationOperator>
    {
        public abstract string Id { get; }
        public abstract string DisplayName { get; }
        public abstract ICalculationValidationResult ValidateOperator(ICalculationOperator calculationOperator);
    }
}