using System;
using System.Collections.Generic;

namespace Math.Calculator.Core
{
    public abstract class Calculator : ICalculationRoot
    {
        private readonly string _name;
        private readonly IReadOnlyList<ICalculationOperator> _operators;

        protected Calculator(string name)
        {
            _name = name;

            _operators = InitOperators();
        }

        public IReadOnlyList<ICalculationOperator> Operators => _operators;


        private IReadOnlyList<ICalculationOperator> InitOperators()
        {
            try
            {
                return BuildOperators();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return new List<ICalculationOperator>(0);
        }

        protected abstract IReadOnlyList<ICalculationOperator> BuildOperators();
    }
}