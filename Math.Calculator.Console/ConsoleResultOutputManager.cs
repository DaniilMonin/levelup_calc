using System;
using Math.Calculator.Core;

namespace Math.Calculator.Console
{
    public sealed class ConsoleResultOutputManager : IResultOutputManager
    {
        public void Render(double result)
        {
            System.Console.WriteLine($"Result is {result}");
        }

        public void Render(ICalculationValidationResult validationResult)
        {
            foreach (ICalculationValidationMessageResult messageResult in validationResult.Messages)
            {
                System.Console.WriteLine($"{messageResult.Property} - {messageResult.Message}");
            }
        }

        public void Error<TException>(TException exception) where TException : Exception
        {
            System.Console.WriteLine(exception.Message);
        }
    }
}