using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace upravnikKT2.Validation
{

    public class MinimumCharactersRule : ValidationRule
    {
        public int MinimumCharacters { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string charString = value as string;
                if (charString.Length < MinimumCharacters)
                    return new ValidationResult(false, $"Use at least {MinimumCharacters} characters");

                 return new ValidationResult(true, null);
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }

        
    }

    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "Polje za unos mora biti popunjeno.")
                : ValidationResult.ValidResult;

        }
    }
    public class JMBGValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            try
            {
                var s = value as string;
                if (s.Length == 13)  //TODO: NE RADI ZA 13 SLOVA
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Morate uneti 13 brojeva za JMBG.");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }

    public class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            try
            {
                var s = value as string;
                bool isEmail = Regex.IsMatch(s, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (isEmail)
                    return new ValidationResult(true, null);

                return new ValidationResult(false, "Format email-a xxxx@xx.x");

            }
            catch
            {
                return new ValidationResult(false, "Niste dobro uneli email.");
            }
        }
    }

    public class PhoneValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            try
            {
                var s = value as string;
                bool isPhone = Regex.IsMatch(s, "^+(?:[0-9]●?){6,14}[0-9]$", RegexOptions.IgnoreCase);
                if (isPhone)
                    return new ValidationResult(true, null);

                return new ValidationResult(false, "Niste dobro uneli telefon.");

            }
            catch
            {
                return new ValidationResult(false, "Niste dobro uneli telefon.");
            }
        }
    }

    public class OnlyNumbersValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                int r;
                if (int.TryParse(s, out r))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Unesite broj");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
    

    public class MinMaxValidationRule : ValidationRule
    {
        public double Min
        {
            get;
            set;
        }

        public double Max
        {
            get;
            set;
        }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value is double)
            {
                double d = (double)value;
                if (d < Min) return new ValidationResult(false, "Value too small.");
                if (d > Max) return new ValidationResult(false, "Value too large.");
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
}
