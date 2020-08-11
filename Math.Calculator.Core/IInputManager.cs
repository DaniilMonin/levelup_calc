using System.Collections.Generic;

namespace Math.Calculator.Core
{
    public interface IInputManager
    {

        IInputManagerResult Execute(IReadOnlyList<ICalculationOperator> operators);
    }
}