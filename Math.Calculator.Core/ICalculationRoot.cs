using System.Collections.Generic;

namespace Math.Calculator.Core
{
    public interface ICalculationRoot
    {
        IReadOnlyList<ICalculationOperator> Operators { get; }
    }
}