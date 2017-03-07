using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Common;

namespace SchoolSystem.Framework.Models
{
    public class Mark : IMark
    {
        private readonly string markValueExceptionMessage = $"The value of the mark must be between {Constants.MinValue} and {Constants.MaxValue}";
        private float value;

        public Mark(Subject subject, float value)
        {
            this.Subject = subject;
            this.Value = value;
        }

        public Subject Subject { get; private set; }

        public float Value
        {
            get
            {
                return this.value;
            }

            private set
            {
                Validator.ValidateFloatRange(value, Constants.MinValue, Constants.MaxValue, markValueExceptionMessage);
                this.value = value;
            }
        }
    }
}
