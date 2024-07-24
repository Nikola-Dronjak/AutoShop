using System.ComponentModel.DataAnnotations;

namespace AutoShop.ViewModel
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GreaterThanIfBothSpecifiedAttribute : ValidationAttribute
    {
        private readonly string _otherProperty;
        public GreaterThanIfBothSpecifiedAttribute(string otherProperty)
        {
            _otherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(_otherProperty);

            if (otherPropertyInfo != null)
            {
                var otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

                // Check if both YearFrom and YearTo have values before applying GreaterThan validation
                if (otherPropertyValue != null && value != null)
                {
                    if ((int)value <= (int)otherPropertyValue)
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
