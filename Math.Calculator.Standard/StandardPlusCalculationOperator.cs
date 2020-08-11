using System;
using System.Collections.Generic;
using Math.Calculator.Core;

namespace Math.Calculator.Standard
{
    internal sealed class StandardPlusCalculationOperator : CalculationOperator
    {
        protected override double DoExecute(ICalculationOperationArguments arguments)
        {
            return default;
        }

        public StandardPlusCalculationOperator(IResultOutputManager outputManager) : base(outputManager)
        {
        }
    }
}