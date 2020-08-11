using System;

namespace Math.Calculator.Core
{
    public interface ICalculationOperator
    {
        Guid Id { get; }

        string DisplayName { get; }

        void Execute(ICalculationOperationArguments arguments);
    }

}