using System;
using Math.Calculator.Core;
using Math.Calculator.Core.Operators;
using Math.Calculator.Core.Validators;

namespace Math.Calculator.Standard
{
    internal sealed class StandardDivideCalculationOperator : CalculationOperator, IDivideCalculationOperator
    {
        private readonly Guid _id = new Guid("7D27788A-C470-4E18-9A78-8B97A0FD8395");

        private ICalculationOperationArguments _currentArguments;

        public StandardDivideCalculationOperator(IResultOutputManager outputManager) : base(outputManager)
        {
            //AddValidatorItem(new DivideByZeroCalculationOperatorValidator());
        }

        public double FirstArgument
        {
            get
            {
                return _currentArguments.FirstArgument;
            }
        }

        public double SecondArgument
        {
            get
            {
                return _currentArguments.SecondArgument;
            }
        }

        public override Guid Id
        {
            get
            {
                return _id;
            }
        }

        protected override double DoExecute(ICalculationOperationArguments arguments)
        {
            return arguments.FirstArgument / arguments.SecondArgument;
        }
    }
}