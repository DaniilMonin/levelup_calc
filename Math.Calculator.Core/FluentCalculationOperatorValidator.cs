using System;
using FluentValidation;
using FluentValidation.Results;

namespace Math.Calculator.Core
{
    public abstract class FluentCalculationOperatorValidator<TItem> : AbstractValidator<TItem>, ICalculationOperatorValidator<TItem>
        where TItem : class, ICalculationOperator
    {
        private readonly CalculationValidationResult _calculationValidationResult;

        protected FluentCalculationOperatorValidator()
        {
            _calculationValidationResult = new CalculationValidationResult(GetUniqueIdentifier());
        }

        public abstract string Id { get; }
        public abstract string DisplayName { get; }

        public ICalculationValidationResult ValidateOperator(TItem calculationOperator)
        {
            if (!IsConfigured)
            {
                IsConfigured = Setup();
            }

            _calculationValidationResult.Clear();

            Invalidate(calculationOperator);

            return _calculationValidationResult;
        }

        private string GetUniqueIdentifier()
        {
            try
            {
                return Id;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return string.Empty;
        }

        protected virtual void Invalidate(TItem calculationOperator)
        {
            ValidationResult result = this.Validate(calculationOperator);

            foreach (var error in result.Errors)
            {
                AddMessage(error.PropertyName, error.ErrorMessage);
            }
        }

        protected void AddMessage(string propertyName, string message)
        {
            _calculationValidationResult.Add(propertyName, message);
        }

        private bool IsConfigured { get; set; }

        protected virtual bool Setup()
        {

            return false;
        }
    }
}