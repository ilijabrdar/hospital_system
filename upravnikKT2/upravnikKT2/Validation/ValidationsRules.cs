using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
                ? new ValidationResult(false, "Polje mora biti popunjeno.")
                : ValidationResult.ValidResult;

        }
    }

    public class BirthDateValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = (DateTime)value;
                DateTime latest = new DateTime(2000, 01, 01);
                DateTime earliest = new DateTime(1919, 12, 31);
                if (DateTime.Compare(s, latest) <0 && DateTime.Compare(s,earliest)>0)
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Dozvoljen datum rodjenja je izmedju 2000. i 1920. godine");
            }
            catch
            {
                return new ValidationResult(false, "Dozvoljen datum rodjenja je izmedju 2000. i 1920. godine");
            }
        }
    }

    public class StartShiftDateValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = (DateTime)value;
                DateTime latest = DateTime.Now.AddMonths(1);
                DateTime earliest = DateTime.Now;
                if (DateTime.Compare(s, latest) < 0 && DateTime.Compare(s, earliest) > 0)
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Raspon pocetka smene je mesec dana");
            }
            catch
            {
                return new ValidationResult(false, "Raspon pocetka smene je mesec dana");
            }
        }
    }

    public class JMBGValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            try
            {
                bool isJMBG = Regex.IsMatch(value as string, "^[0-9]{13}$", RegexOptions.IgnoreCase);

                if (isJMBG)  
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Morate uneti 13 brojeva za JMBG");
            }
            catch
            {
                return new ValidationResult(false, "Morate uneti 13 brojeva za JMBG");
            }
        }
    }

    public class NameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            try
            {
                bool isJMBG = Regex.IsMatch(value as string, "^[a-zA-Z]+[\\s|-]?[a-zA-Z]+[\\s|-]?[a-zA-Z]+$", RegexOptions.IgnoreCase);

                if (isJMBG)
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Ime mora imati bar 3 slova");
            }
            catch
            {
                return new ValidationResult(false, "Ime mora imati bar 3 slova");
            }
        }
    }

    public class SurnameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            try
            {
                bool isJMBG = Regex.IsMatch(value as string, "^[a-zA-Z]+[\\s|-]?[a-zA-Z]+[\\s|-]?[a-zA-Z]+$", RegexOptions.IgnoreCase);

                if (isJMBG)
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Prezime mora imati bar 3 slova");
            }
            catch
            {
                return new ValidationResult(false, "Prezime mora imati bar 3 slova");
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

                return new ValidationResult(false, "Primer email-a: naziv@domen.com");

            }
            catch
            {
                return new ValidationResult(false, "Primer email-a: naziv@domen.com");
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

                return new ValidationResult(false, "Telefon mora imati bar 7 cifara");

            }
            catch
            {
                return new ValidationResult(false, "Telefon mora imati bar 7 cifara");
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
                if (int.TryParse(s, out r) && r>0)
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Unesite pozitivan broj");
            }
            catch
            {
                return new ValidationResult(false, "Unesite pozitivan broj");
            }
        }
    }

    public class PasswordValidation : ValidationRule
    {
        public static String password1 = "";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                password1 = value as string;
                PasswordValidation2.password2 = password1;
                /*  if (pw = Regex.IsMatch(s, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{1,4}$", RegexOptions.IgnoreCase)){
                      return new ValidationResult(false, "Password is weak.");
                  }
                  else if(pw = Regex.IsMatch(s, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{4,}$", RegexOptions.IgnoreCase))
                  {
                      return new ValidationResult(true, "Password is medium.");
                  }*/
                if (password1 == null)
                {
                    return new ValidationResult(false, "!");
                }
                if (password1.Equals("") || password1 == null)
                {

                    password1 = "";
                    return new ValidationResult(false, "Lozinka ne sme ostati prazna!");

                }
                else
                {

                    password1 = "";
                    return new ValidationResult(true, null);
                }



            }
            catch
            {
                return new ValidationResult(false, "Password is weak.");
            }
        }
    }

    public class PasswordValidation2 : ValidationRule
    {
        public static String password1;
        public static String password2;
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                password1 = value as string;
                Console.WriteLine(password2);
                /*  if (pw = Regex.IsMatch(s, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{1,4}$", RegexOptions.IgnoreCase)){
                      return new ValidationResult(false, "Password is weak.");
                  }
                  else if(pw = Regex.IsMatch(s, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{4,}$", RegexOptions.IgnoreCase))
                  {
                      return new ValidationResult(true, "Password is medium.");
                  }*/
                if (password1 == null)
                {
                    return new ValidationResult(false, "!");
                }
                if (password1.Equals("") || password1 == null)
                {

                    return new ValidationResult(false, "Lozinka ne sme ostati prazna!");

                }
                else if (!password1.Equals(password2))
                {


                    return new ValidationResult(false, "Lozinke se ne poklapaju!");
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

