using System;
using System.Collections.Generic;
using System.Linq;

namespace Math.Calculator.Core
{
    public abstract class Calculator : ICalculationRoot
    {
        private readonly string _name;
        private readonly IInputManager _inputManager;
        private readonly IResultOutputManager _resultOutputManager;
        private readonly IReadOnlyList<ICalculationOperator> _operators;

        protected Calculator(string name, IInputManager inputManager, IResultOutputManager resultOutputManager)
        {
            _name = name;
            _inputManager = inputManager;
            _resultOutputManager = resultOutputManager;

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

        protected IResultOutputManager OutputManager
        {
            get { return _resultOutputManager; }
        }

        public void Start()
        {
            IInputManagerResult result = _inputManager.Execute(_operators);

            ICalculationOperator oper = _operators.FirstOrDefault(@operator => @operator.Id == result.IdOperator);

            if (oper is null)
            {
                return;
            }

            oper.Execute(result);
        }
    }
}