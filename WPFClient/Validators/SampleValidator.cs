using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace WPFClient.Validators
{
    public class SampleValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string valueToValidate = value as string;
            if(!string.IsNullOrEmpty(valueToValidate))
            {
                if(valueToValidate.Length<5)
                {
                    return new ValidationResult(false, "For Test only value should be at least 5 characters length");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
    public class DateTimeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            DateTime valueToValidate;
            if(DateTime.TryParse(value.ToString(),out valueToValidate))
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Invalid date time");
        }
    }

}
