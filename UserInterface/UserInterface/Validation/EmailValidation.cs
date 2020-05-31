using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Globalization;

namespace UserInterface.Validation
{
    class EmailValidation : ValidationRule
    {
        private readonly Regex _regEx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (_regEx.IsMatch(val))
                return new ValidationResult(true, null);
            return new ValidationResult(false, "Neispravan format E-mail adrese.");
        }
    }
}
