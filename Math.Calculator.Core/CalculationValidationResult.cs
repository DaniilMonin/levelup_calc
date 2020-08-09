using System.Collections.Generic;

namespace Math.Calculator.Core
{
    internal sealed class CalculationValidationResult : ICalculationValidationResult
    {
        private readonly string _validatorId;
        private readonly List<ICalculationValidationMessageResult> _messages = new List<ICalculationValidationMessageResult>();

        public CalculationValidationResult(string validatorId)
        {
            _validatorId = validatorId;
        }

        public bool IsValid
        {
            get { return _messages.Count == 0; }
        }

        public string ValidatorId
        {
            get { return _validatorId; }
        }

        public IReadOnlyList<ICalculationValidationMessageResult> Messages
        {
            get { return _messages; }
        }

        public void Add(string propertyName, string message)
        {
            _messages.Add(
                new ValidationMessage
                {
                    Property = propertyName,
                    Message = message
                });
        }

        public void Clear()
        {
            _messages.Clear();
        }

        private sealed class ValidationMessage : ICalculationValidationMessageResult
        {
            public string Property { get; set; }
            public string Message { get; set; }
        }
    }
}