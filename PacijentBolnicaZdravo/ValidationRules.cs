using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            if(value == null)
            {
                return new ValidationResult(false, "Polje za unos mora biti popunjeno.");
            }
            if (value.ToString() == "" || value == null)
            {
                if (Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
                {
                    return new ValidationResult(false, "Polje za unos mora biti popunjeno.");
                }
                return new ValidationResult(false, "The input field must be filled.");
            }
            return  ValidationResult.ValidResult;
        }



    }

    class DateTimeValidationRule : ValidationRule
    {
        public DateTimeValidationRule()
        {

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
           if((DateTime)value > DateTime.Today)
            {
                if (!Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
                {
                    return new ValidationResult(false, "It is not possible to enter a date greater than today!");
                }
                return new ValidationResult(false, "Nije moguce uneti datum veci od danasnjeg!");
            }
            return ValidationResult.ValidResult;
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

                if (!Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
                {
                    return new ValidationResult(false, "You must enter 13 numbers for the ID.");
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

                return new ValidationResult(false, "Format e-mail xxxx@xx.x");

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

                if (!Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
                {
                    return new ValidationResult(false, "Phone number is not in correct format!");
                }
                return new ValidationResult(false, "Broj telefona nije u dobrom formatu!" );

            }
            catch
            {
                return new ValidationResult(false, "Niste dobro uneli telefon.");
            }
        }
    }


    public class LogInValidation : ValidationRule
    {
        public static String badUserString = "";
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var badUser = value as string;
                if(badUser == null)
                {

                    if (!Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
                    {
                        return new ValidationResult(false, "Login required!");
                    }
                    return new ValidationResult(false, "Potrebno je uneti podatka za logovanje!");
                }
                if (badUserString.Equals("badUserString"))
                {
                    if (!Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
                    {
                        badUserString = "";
                        return new ValidationResult(false, "Wrong username or password!");
                    }
                    badUserString = "";
                    return new ValidationResult(false, "Pogrešno uneto korisničko ime ili lozinka!");
                }
                if(badUser == "")
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(true, null);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
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

                    if (!Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
                    {
                        
                        password1 = "";
                        return new ValidationResult(false, "Password can not be empty!");
                    }
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
                  if(password1 == null)
                {
                    return new ValidationResult(false, "!");
                }
                if (password1.Equals("") || password1 == null)
                {

                    if (!Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
                    {
                        return new ValidationResult(false, "Password can not be empty!");
                    }

                    return new ValidationResult(false, "Lozinka ne sme ostati prazna!");

                }
                else if (!password1.Equals(password2))
                {
                    if (!Thread.CurrentThread.CurrentCulture.Equals(new CultureInfo("sr")))
                    {

                        return new ValidationResult(false, "Password did not matched!");
                    }

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
