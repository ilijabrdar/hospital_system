using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PacijentBolnicaZdravo
{
    class ValidationRules : ValidationRule
    {
        public ValidationRules()
        {

        }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            return string.IsNullOrWhiteSpace((value ?? "").ToString())
               ? new ValidationResult(false, "Polje za unos mora biti popunjeno.")
               : ValidationResult.ValidResult;
        }



    }
    class JMBGValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;

                if (s.Length == 13)
                {
                    if (s.Any(char.IsDigit))
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

    public class PhoneValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                bool isPhone = Regex.IsMatch(s, @"^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", RegexOptions.IgnoreCase);
                if (isPhone)
                    return new ValidationResult(true, null);

                return new ValidationResult(false, "Phone number is not in correct format");

            }
            catch
            {
                return new ValidationResult(false, "Niste dobro uneli email.");
            }
        }
    }

    public class PasswordValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                bool pw;
                if (pw = Regex.IsMatch(s, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{1,4}$", RegexOptions.IgnoreCase)){
                    return new ValidationResult(false, "Password is weak.");
                }
                else if(pw = Regex.IsMatch(s, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{4,}$", RegexOptions.IgnoreCase))
                {
                    return new ValidationResult(true, "Password is medium.");
                }
                else
                {
                    return new ValidationResult(true, null);
                }

                

            }
            catch
            {
                return new ValidationResult(false, "Password is weak.");
            }
        }
    }

}
