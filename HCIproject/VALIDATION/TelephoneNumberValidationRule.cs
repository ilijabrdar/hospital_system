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
    public class TelephoneNumberValidationRule : ValidationRule
    {
        private readonly Regex _regex = new Regex(@"^[+]*[0-9]{10,13}$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = (String)value;

            if (String.IsNullOrEmpty(val)) return new ValidationResult(false, "Neophodno je popuniti ovo polje.");
            if (!_regex.Match(val).Success) return new ValidationResult(false, "Dozvoljeni formati +3810640324532 i 0640324532");
            return new ValidationResult(true, null);
        }
    }
}
