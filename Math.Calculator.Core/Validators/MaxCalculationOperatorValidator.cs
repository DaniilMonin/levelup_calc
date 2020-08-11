using FluentValidation;
using Math.Calculator.Core.Operators;

namespace Math.Calculator.Core.Validators
{
    public sealed class MaxCalculationOperatorValidator : FluentCalculationOperatorValidator<IDivideCalculationOperator>
    {

        private readonly double _maxFirstArgument = 0;
        private readonly double _maxSecondArgument = 0;


        public MaxCalculationOperatorValidator(ISettingsService settingsService)
        {
            _maxFirstArgument = settingsService.GetProperty("Max_First_Argument_MaxCalculationOperatorValidator");
            _maxSecondArgument = settingsService.GetProperty("Max_Second_Argument_MaxCalculationOperatorValidator");
        }


        public override string Id
        {
            get { return nameof(MaxCalculationOperatorValidator); }
        }

        public override string DisplayName
        {
            get { return Id; }
        }

        protected override bool Setup()
        {
            RuleFor(x => x.FirstArgument).
                GreaterThanOrEqualTo(_maxFirstArgument).
                WithMessage($"First Argument should be greater than {_maxFirstArgument}");

            RuleFor(x => x.SecondArgument).
                GreaterThanOrEqualTo(_maxSecondArgument).
                WithMessage($"Second Argument should be greater than {_maxSecondArgument}");

            return true;
        }
    }
}