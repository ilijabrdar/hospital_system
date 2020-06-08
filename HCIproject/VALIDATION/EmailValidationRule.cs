using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCIproject.Validation
{
    public class EmailValidationRule : ValidationRule
    {
        private readonly Regex _regex = new Regex(@"^[A-Za-z0-9_\-\.]+[@][a-z]+\.[a-z]+$");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = (String)value;

            if (String.IsNullOrEmpty(val)) return new ValidationResult(false, "Neophodno je popuniti ovo polje.");
            if (!_regex.Match(val).Success) return new ValidationResult(false, "Unosite email adresu u formatu primer@gmail.com");
            return new ValidationResult(true, null);
        }
    }
}
