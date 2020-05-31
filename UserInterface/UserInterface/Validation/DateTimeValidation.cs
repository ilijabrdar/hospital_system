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
    public class DayValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (MainWindow.Month != 0 && MainWindow.Year != 0)
            {
                if (int.TryParse(val, out int day))
                {
                    if (day < 1 || day > DateTime.DaysInMonth(MainWindow.Year, MainWindow.Month))
                        return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(MainWindow.Year, MainWindow.Month));
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(MainWindow.Year, MainWindow.Month));
            }
            else
            {
                if (int.TryParse(val, out int day))
                {
                    if (day < 1 || day > 31)
                        return new ValidationResult(false, "1 - 31");
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "1 - 31");
            }
        }
    }

    public class GuestDayValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (MainWindow.NewMonth != 0 && MainWindow.NewYear != 0)
            {
                if (int.TryParse(val, out int day))
                {
                    if (day < 1 || day > DateTime.DaysInMonth(MainWindow.NewYear, MainWindow.NewMonth))
                        return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(MainWindow.NewYear, MainWindow.NewMonth));
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(MainWindow.NewYear, MainWindow.NewMonth));
            }
            else
            {
                if (int.TryParse(val, out int day))
                {
                    if (day < 1 || day > 31)
                        return new ValidationResult(false, "1 - 31");
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "1 - 31");
            }
        }
    }

    public class FromDayReportValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Ovo polje je obavezno.");

            if (Report.FromMonth != 0 && Report.FromYear != 0)
            {
                if (int.TryParse(val, out int day))
                {
                    if (day < 1 || day > DateTime.DaysInMonth(Report.FromYear, Report.FromMonth))
                        return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(Report.FromYear, Report.FromMonth));
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(Report.FromYear, Report.FromMonth));
            }
            else
            {
                if (int.TryParse(val, out int day))
                {
                    if (day < 1 || day > 31)
                        return new ValidationResult(false, "1 - 31");
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "1 - 31");
            }
        }
    }

    public class MonthValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Ovo polje je obavezno.");

            if (int.TryParse(val, out int month))
            {
                if(month < 1 || month > 12)
                {
                    return new ValidationResult(false, "1 - 12");
                }
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "1 - 12");
        }
    }

    public class YearValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Ovo polje je obavezno.");

            if (int.TryParse(val, out int year))
            {
                if (year > DateTime.Now.Year || year < 1)
                {
                    return new ValidationResult(false, "1 - " + DateTime.Now.Year);
                }
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "1 - " + DateTime.Now.Year);
        }
    }

    public class MinuteValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Ovo polje je obavezno.");

            if (int.TryParse(val, out int minute))
            {
                if (minute > 59 || minute < 0)
                {
                    return new ValidationResult(false, "0 - 59");
                }
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "0 - 59");
        }
    }

    public class HourValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String; 
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Ovo polje je obavezno.");

            if (int.TryParse(val, out int hour))
            {
                if (hour > 23 || hour < 0)
                {
                    return new ValidationResult(false, "0 - 23");
                }
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "0 - 23");
        }
    }
}
