using System.Collections.Generic;
using Math.Calculator.Core;

namespace Math.Calculator.Standard
{

    public /*internal*/ sealed class StandardCalculator : Core.Calculator
    {
        public StandardCalculator(string name) : base(name)
        {
        }

        protected override IReadOnlyList<ICalculationOperator> BuildOperators()
        {
            return new List<ICalculationOperator>()
            {
                new StandardMinusCalculationOperator(),
                new StandardPlusCalculationOperator(),
                new StandardMultiplicationCalculationOperator(),
                new StandardDivideCalculationOperator()
            };
        }
    }
} 