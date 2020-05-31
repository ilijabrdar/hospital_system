using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UserInterface.Validation
{
    public class OnlyStringValidationRule : ValidationRule
    {
        private readonly Regex _regEx = new Regex(@"^[A-Za-zČĆŽĐŠ]+$");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Ovo polje je obavezno.");

            if (_regEx.Match(val).Success)
                return new ValidationResult(true, null);
            return new ValidationResult(false, "Uneta vrednost mora sadržati isključivo karaktere.");
        }
    }
}
