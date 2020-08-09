using System.Collections.Generic;

namespace Math.Calculator.Core
{
    public interface ICalculationValidationResult
    {
        bool IsValid { get; }

        string ValidatorId { get; }

        IReadOnlyList<ICalculationValidationMessageResult> Messages { get; }
    }
}