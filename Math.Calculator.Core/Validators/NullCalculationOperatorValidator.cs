using FluentValidation;
using FluentValidation.Results;

namespace Math.Calculator.Core.Validators
{
    public sealed class NullCalculationOperatorValidator : FluentCalculationOperatorValidator<ICalculationOperator>
    {
        public override string Id
        {
            get { return nameof(NullCalculationOperatorValidator); }
        }

        public override string DisplayName
        {
            get { return Id; }
        }

        protected override bool Setup()
        {
            RuleFor(x => x.DisplayName).
                NotEmpty().
                WithMessage("Display name could not be empty");

            RuleFor(x => x.DisplayName).
                Length(1, 20).
                WithMessage("Display Name should be 1 or 20 letters");

            return true;
        }

    }
}