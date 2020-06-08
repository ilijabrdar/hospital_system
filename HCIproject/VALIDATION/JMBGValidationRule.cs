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
    class JMBGValidationRule : ValidationRule
    {
        private readonly Regex _regex = new Regex(@"^[0-9]{13}$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String _string = value as String;

            if (String.IsNullOrEmpty(_string)) return new ValidationResult(false, "Neophodno je popuniti ovo polje.");

            try
            {
                double _double;
                if (double.TryParse(_string, out _double))
                {
                    if (_string.Trim().Length != 13)
                    {
                        return new ValidationResult(false, "JMBG se sastoji od tačno 13 cifara.");
                    }
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "JMBG se sastoji od 13 cifara i neophodno ga je uneti bez dodatnih karaktera.");
            }
            catch
            {
                return new ValidationResult(false, "JMBG se sastoji od 13 cifara i neophodno ga je uneti bez dodatnih karaktera.");
            }

          
        }
    }
}
