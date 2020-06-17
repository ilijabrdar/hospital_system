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
    public class StringValidationRule : ValidationRule
    {
        private Regex _regex = new Regex("^[A-Za-zŠĐŽĆČšđžćč]+[ ]*[A-Za-zŠĐŽĆČšđžćč]*$");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = (String)value;

            if(String.IsNullOrEmpty(val)) return new ValidationResult(false, "Neophodno je popuniti ovo polje.");
            if (!_regex.Match(val).Success) return new ValidationResult(false, "U ovo polje je dozvoljen unos isključivo karaktera.");
            return new ValidationResult(true, null);
        }
    }
}