using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UserInterface.Validation
{
    class JMBGValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Ovo polje je obavezno.");

            if (long.TryParse(val, out _))
            {
                if (val.Trim().Length != 13)
                    return new ValidationResult(false, "Broj cifara mora biti 13.");
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Uneta vrednost ne predstavlja broj.");
        }
    }
}
