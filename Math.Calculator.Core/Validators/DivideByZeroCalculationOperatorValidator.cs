using FluentValidation;
using Math.Calculator.Core.Operators;

namespace Math.Calculator.Core.Validators
{
    public sealed class DivideByZeroCalculationOperatorValidator : FluentCalculationOperatorValidator<IDivideCalculationOperator>
    {
        public override string Id
        {
            get { return nameof(DivideByZeroCalculationOperatorValidator); }
        }

        public override string DisplayName
        {
            get { return Id; }
        }

        protected override bool Setup()
        {
            RuleFor(x => x.SecondArgument).
                GreaterThanOrEqualTo(1).
                WithMessage("Can not divide by zero");

            return true;
        }
    }
}