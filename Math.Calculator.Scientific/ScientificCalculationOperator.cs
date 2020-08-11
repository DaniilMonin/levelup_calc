using Math.Calculator.Core;

namespace Math.Calculator.Scientific
{
    internal abstract class ScientificCalculationOperator : CalculationOperator
    {
        protected override double DoExecute(ICalculationOperationArguments arguments)
        {
            return default;
        }

        protected ScientificCalculationOperator(IResultOutputManager outputManager) : base(outputManager)
        {
        }
    }
}