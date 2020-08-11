using System;

namespace Math.Calculator.Core
{
    public interface IResultOutputManager
    {
        void Render(double result);
        void Render(ICalculationValidationResult validationResult);

        void Error<TException>(TException exception)
            where TException : Exception;
    }
}