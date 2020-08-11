using System;
using System.Collections.Generic;
using Math.Calculator.Core.Validators;

namespace Math.Calculator.Core
{
    public abstract class CalculationOperator : ICalculationOperator
    {
        private readonly IResultOutputManager _outputManager;
        private readonly IDictionary<string, ICalculationOperatorValidator<ICalculationOperator>> _validators = new Dictionary<string, ICalculationOperatorValidator<ICalculationOperator>>();

        protected CalculationOperator(IResultOutputManager outputManager)
        {
            _outputManager = outputManager;

            AddValidatorItem(new NullCalculationOperatorValidator());
        }

        public virtual string DisplayName
        {
            get { return nameof(CalculationOperator); }
        }

        public virtual Guid Id
        {
            get
            {


                return Guid.Empty;
            }
        }

        public void Execute(ICalculationOperationArguments arguments)
        {
            try
            {
                bool isValid = true;

                IReadOnlyList<ICalculationValidationResult> validationResults = Validate();

                foreach (ICalculationValidationResult validationResult in validationResults)
                {
                    if (validationResult.IsValid)
                    {
                        continue;
                    }

                    _outputManager.Render(validationResult);

                    isValid = false;
                }

                if (isValid)
                {
                    _outputManager.Render(DoExecute(arguments));
                }
            }
            catch (Exception exception)
            {
                _outputManager.Error(exception);
            }
        }

        protected virtual IReadOnlyList<ICalculationValidationResult> Validate()
        {
            List<ICalculationValidationResult> validationResults = new List<ICalculationValidationResult>();

            foreach (KeyValuePair<string, ICalculationOperatorValidator<ICalculationOperator>> pairItem in _validators)
            {
                ICalculationOperatorValidator<ICalculationOperator> validator = pairItem.Value;

                if (validator is null)
                {
                    validationResults.Add(new NullValidationResult(pairItem.Key));

                    continue;
                }

                ICalculationValidationResult result = validator.ValidateOperator(this);

                if (result.IsValid)
                {
                    continue;
                }

                validationResults.Add(result);
            }

            return validationResults;
        }

        protected void AddValidatorItem(ICalculationOperatorValidator<ICalculationOperator> validator)
        {
            if (validator is null)
            {
                return;
            }

            if (_validators.TryGetValue(validator.Id, out ICalculationOperatorValidator<ICalculationOperator> operatorValidator))
            {
                return;
            }

            _validators.Add(validator.Id, validator);
        }

        protected virtual double DoExecute(ICalculationOperationArguments arguments)
        {
            return default;
        }


        private sealed class NullValidationResult : ICalculationValidationResult
        {
            private static readonly IReadOnlyList<ICalculationValidationMessageResult> _validationMessages =
                new List<ICalculationValidationMessageResult>
                {

                };

            private readonly string _id;

            public NullValidationResult(string id)
            {
                _id = id;
            }

            public bool IsValid
            {
                get { return false; }
            }

            public string ValidatorId
            {
                get
                {
                    return _id;
                }
            }

            public IReadOnlyList<ICalculationValidationMessageResult> Messages => _validationMessages;
        }

    }
}