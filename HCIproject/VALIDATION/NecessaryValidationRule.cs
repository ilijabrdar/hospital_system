using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCIproject.Validation
{
    public class NecessaryValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = (String)value;

            if (String.IsNullOrEmpty(val)) return new ValidationResult(false, "Neophodno je popuniti ovo polje.");
            return new ValidationResult(true, null);
        }
    }
    
}
