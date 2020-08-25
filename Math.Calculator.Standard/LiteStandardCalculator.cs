using System.Collections.Generic;
using Math.Calculator.Core;

namespace Math.Calculator.Standard
{
    public /*internal*/ sealed class LiteStandardCalculator : Core.Calculator
    {
        public LiteStandardCalculator(string name, IInputManager inputManager, IResultOutputManager resultOutputManager) : base(name, inputManager, resultOutputManager)
        {
        }

        protected override IReadOnlyList<ICalculationOperator> BuildOperators()
        {
            return new List<ICalculationOperator>()
            {
                new StandardMinusCalculationOperator(OutputManager),
                new StandardPlusCalculationOperator(OutputManager),
            };
        }
    }
}