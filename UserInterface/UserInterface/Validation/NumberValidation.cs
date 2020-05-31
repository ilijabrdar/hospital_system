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
    //class NumberValidation : ValidationRule
    //{
    //    private readonly Regex _regEx = new Regex(@"^[1-9]+[0-9]*[A-Za-z]?$");
    //    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    //    {
    //        String val = value as String;
    //        if (_regEx.IsMatch(val))
    //            return new ValidationResult(true, null);
    //        return new ValidationResult(false, "Primer formata broja: 8, 8a");
    //    }
    //}

    class PhoneValidation : ValidationRule
    {
        private readonly Regex _regEx = new Regex(@"^\+?[0-9]+$");
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Ovo polje je obavezno.");
            if (_regEx.IsMatch(val))
                return new ValidationResult(true, null);
            return new ValidationResult(false, "Ispravni formati: +3810657849112, 0657849112");
        }
    }
}
