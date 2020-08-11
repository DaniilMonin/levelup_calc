using System;

namespace Math.Calculator.Core
{
    public interface IInputManagerResult : ICalculationOperationArguments
    {
        Guid IdOperator { get; }
    }
}