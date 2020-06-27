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
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (!String.IsNullOrEmpty(MainWindow.NewMonth) && !String.IsNullOrEmpty(MainWindow.NewYear))
            {
                if (int.TryParse(val, out int day))
                {
                    if (day < 1 || day > DateTime.DaysInMonth(int.Parse(MainWindow.NewYear), int.Parse(MainWindow.NewMonth)))
                        return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(int.Parse(MainWindow.NewYear), int.Parse(MainWindow.NewMonth)));
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(int.Parse(MainWindow.NewYear), int.Parse(MainWindow.NewMonth)));
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

    public class DaySearchValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (AppointmentSearch.FromYear != 0 && AppointmentSearch.FromMonth != 0)
            {
                if (int.TryParse(val, out int day))
                {
                    if (day < 1 || day > DateTime.DaysInMonth(AppointmentSearch.FromYear, AppointmentSearch.FromMonth))
                        return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(AppointmentSearch.FromYear, AppointmentSearch.FromMonth));
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(AppointmentSearch.FromYear, AppointmentSearch.FromMonth));
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

    public class DayEditValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (EditAppointment.Year != 0 && EditAppointment.Month != 0)
            {
                if (int.TryParse(val, out int day))
                {
                    if (day < 1 || day > DateTime.DaysInMonth(EditAppointment.Year, EditAppointment.Month))
                        return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(EditAppointment.Year, EditAppointment.Month));
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(EditAppointment.Year, EditAppointment.Month));
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

    public class FromDaySearchValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (int.TryParse(val, out int day))
            {
                if (AppointmentSearch.FromYear == DateTime.Now.Year && AppointmentSearch.FromMonth == DateTime.Now.Month)
                {
                    if (day < DateTime.Now.Day || day > DateTime.DaysInMonth(AppointmentSearch.FromYear, AppointmentSearch.FromMonth))
                        return new ValidationResult(false, DateTime.Now.Day + " - " + DateTime.DaysInMonth(AppointmentSearch.FromYear, AppointmentSearch.FromMonth));
                }
                else
                {
                    if (day < 1 || day > DateTime.DaysInMonth(AppointmentSearch.FromYear, AppointmentSearch.FromMonth))
                        return new ValidationResult(false,  "1 - " + DateTime.DaysInMonth(AppointmentSearch.FromYear, AppointmentSearch.FromMonth));
                }
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, DateTime.Now.Day + " - " + DateTime.DaysInMonth(AppointmentSearch.FromYear, AppointmentSearch.FromMonth));
        }
    }

    public class ToDaySearchValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (int.TryParse(val, out int day))
            {
                if (AppointmentSearch.FromYear == AppointmentSearch.ToYear && AppointmentSearch.FromMonth == AppointmentSearch.ToMonth)
                {
                    if (day < AppointmentSearch.FromDay || day > DateTime.DaysInMonth(AppointmentSearch.ToYear, AppointmentSearch.ToMonth))
                        return new ValidationResult(false, AppointmentSearch.FromDay + " - " + DateTime.DaysInMonth(AppointmentSearch.ToYear, AppointmentSearch.ToMonth));
                }
                else
                {
                    if (day < 1 || day > DateTime.DaysInMonth(AppointmentSearch.ToYear, AppointmentSearch.ToMonth))
                        return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(AppointmentSearch.ToYear, AppointmentSearch.ToMonth));
                }
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(AppointmentSearch.FromYear, AppointmentSearch.FromMonth));
        }
    }

    public class FromDayReportValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

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

    public class FromDayFilterValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (AppointmentFilter.FromMonth != 0 && AppointmentFilter.FromYear != 0)
            {
                if (int.TryParse(val, out int day))
                {
                    if (day < 1 || day > DateTime.DaysInMonth(AppointmentFilter.FromYear, AppointmentFilter.FromMonth))
                        return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(AppointmentFilter.FromYear, AppointmentFilter.FromMonth));
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(AppointmentFilter.FromYear, AppointmentFilter.FromMonth));
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

    public class ToDayReportValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (Report.ToMonth != 0 && Report.ToYear != 0)
            {
                if (int.TryParse(val, out int day))
                {

                    if (Report.FromYear == Report.ToYear && Report.FromMonth == Report.ToMonth)
                    {
                        if(Report.FromDay > day || day > DateTime.DaysInMonth(Report.ToYear, Report.ToMonth))
                            return new ValidationResult(false, Report.FromDay + " - " + DateTime.DaysInMonth(Report.ToYear, Report.ToMonth));
                        return ValidationResult.ValidResult;
                    }
                    else if (day < 1 || day > DateTime.DaysInMonth(Report.ToYear, Report.ToMonth))
                        return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(Report.ToYear, Report.ToMonth));
                    else
                        return new ValidationResult(true, null);
                }
                if (Report.FromYear == Report.ToYear && Report.FromMonth == Report.ToMonth)
                    return new ValidationResult(false, Report.FromDay + " - " + DateTime.DaysInMonth(Report.ToYear, Report.ToMonth));
                else
                    return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(Report.ToYear, Report.ToMonth));
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

    public class ToDayFilterValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (AppointmentFilter.ToMonth != 0 && AppointmentFilter.ToYear != 0)
            {
                if (int.TryParse(val, out int day))
                {

                    if (AppointmentFilter.FromYear == AppointmentFilter.ToYear && AppointmentFilter.FromMonth == AppointmentFilter.ToMonth)
                    {
                        if (AppointmentFilter.FromDay > day || day > DateTime.DaysInMonth(AppointmentFilter.ToYear, AppointmentFilter.ToMonth))
                            return new ValidationResult(false, AppointmentFilter.FromDay + " - " + DateTime.DaysInMonth(AppointmentFilter.ToYear, AppointmentFilter.ToMonth));
                        return ValidationResult.ValidResult;
                    }
                    else if (day < 1 || day > DateTime.DaysInMonth(AppointmentFilter.ToYear, AppointmentFilter.ToMonth))
                        return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(AppointmentFilter.ToYear, AppointmentFilter.ToMonth));
                    else
                        return new ValidationResult(true, null);
                }
                if (AppointmentFilter.FromYear == AppointmentFilter.ToYear && AppointmentFilter.FromMonth == AppointmentFilter.ToMonth)
                    return new ValidationResult(false, AppointmentFilter.FromDay + " - " + DateTime.DaysInMonth(AppointmentFilter.ToYear, AppointmentFilter.ToMonth));
                else
                    return new ValidationResult(false, "1 - " + DateTime.DaysInMonth(AppointmentFilter.ToYear, AppointmentFilter.ToMonth));
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

    public class ToMonthReportValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (int.TryParse(val, out int month))
            {
                    if (Report.FromYear == Report.ToYear)
                    {
                        if(Report.FromMonth > month || month > 12)
                            return new ValidationResult(false, Report.FromMonth + " - " + 12);

                    }
                        
                    else if (month > 12 || month < 1)
                        return new ValidationResult(false, "1 - 12");
                    
                return new ValidationResult(true, null);
            }
            if (Report.FromYear == Report.ToYear)
                return new ValidationResult(false, Report.FromMonth + " - " + 12);
            else
                return new ValidationResult(false, "1 - 12");
        }
    }

    public class ToMonthFilterValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (int.TryParse(val, out int month))
            {
                if (AppointmentFilter.FromYear == AppointmentFilter.ToYear)
                {
                    if (AppointmentFilter.FromMonth > month || month > 12)
                        return new ValidationResult(false, AppointmentFilter.FromMonth + " - " + 12);

                }

                else if (month > 12 || month < 1)
                    return new ValidationResult(false, "1 - 12");

                return new ValidationResult(true, null);
            }
            if (AppointmentFilter.FromYear == AppointmentFilter.ToYear)
                return new ValidationResult(false, AppointmentFilter.FromMonth + " - " + 12);
            else
                return new ValidationResult(false, "1 - 12");
        }
    }

    public class MonthValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

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

    public class FromMonthSearchValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (int.TryParse(val, out int month))
            {
                if (AppointmentSearch.FromYear == DateTime.Now.Year)
                {
                    if (month < DateTime.Now.Month || month > 12)
                        return new ValidationResult(false, DateTime.Now.Month + " - 12");
                }
                else
                {
                    if (month < 1 || month > 12)
                    {
                        return new ValidationResult(false, "1 - 12");
                    }
                }
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "1 - 12");
        }
    }

    public class ToMonthSearchValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (int.TryParse(val, out int month))
            {
                if (AppointmentSearch.FromYear == AppointmentSearch.ToYear)
                {
                    if (month < AppointmentSearch.FromMonth || month > 12)
                        return new ValidationResult(false, AppointmentSearch.FromMonth + " - 12");
                }
                else
                {
                    if (month < 1 || month > 12)
                    {
                        return new ValidationResult(false, "1 - 12");
                    }
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
                return new ValidationResult(false, "Obavezno");

            if (int.TryParse(val, out int year))
            {
                if (year > DateTime.Now.Year || year < 1900)
                {
                    return new ValidationResult(false, "1900 - " + DateTime.Now.Year);
                }
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "1900 - " + DateTime.Now.Year);
        }
    }

    public class ToYearReportValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (int.TryParse(val, out int year))
            {
                if (year > DateTime.Now.Year + 5 || year < Report.FromYear)
                {
                    return new ValidationResult(false, Report.FromYear + " - " + (DateTime.Now.Year + 5));
                }
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, Report.FromYear + " - " + (DateTime.Now.Year + 5));
        }
    }

    public class ToYearFilterValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (int.TryParse(val, out int year))
            {
                if (year > DateTime.Now.Year + 5 || year < AppointmentFilter.FromYear)
                {
                    return new ValidationResult(false, AppointmentFilter.FromYear + " - " + (DateTime.Now.Year + 5));
                }
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, AppointmentFilter.FromYear + " - " + (DateTime.Now.Year + 5));
        }
    }

    public class FromYearSearchValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");
            if (int.TryParse(val, out int year))
            {
                if (year < DateTime.Now.Year || year > DateTime.Now.Year + 2)
                    return new ValidationResult(false, DateTime.Now.Year + " - " + (DateTime.Now.Year + 2));
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, DateTime.Now.Year + " - " + (DateTime.Now.Year + 2));
        }
    }

    public class ToYearSearchValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");
            if (int.TryParse(val, out int year))
            {
                if (year < AppointmentSearch.FromYear || year > DateTime.Now.Year + 2)
                    return new ValidationResult(false, AppointmentSearch.FromYear + " - " + (DateTime.Now.Year + 2));
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, DateTime.Now.Year + " - " + (DateTime.Now.Year + 2));
        }
    }

    public class MinuteValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

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

    public class ToMinuteValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (int.TryParse(val, out int minute))
            {
                if(Report.FromHour == Report.ToHour)
                {
                    if (minute > 59 || minute < Report.FromMinute)
                    {
                        return new ValidationResult(false, Report.FromMinute + " - 59");
                    }
                }
                else 
                    if (minute > 59 || minute < 0)
                    {
                        return new ValidationResult(false, "0 - 59");
                    }
                return new ValidationResult(true, null);
            }
            if(Report.FromHour == Report.ToHour)
                return new ValidationResult(false, Report.FromMinute + " - 59");
            else
                return new ValidationResult(false, "0 - 59");
        }
    }

    public class ToMinuteFilterValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (int.TryParse(val, out int minute))
            {
                if (AppointmentFilter.FromHour == AppointmentFilter.ToHour)
                {
                    if (minute > 59 || minute < AppointmentFilter.FromMinute)
                    {
                        return new ValidationResult(false, AppointmentFilter.FromMinute + " - 59");
                    }
                }
                else
                    if (minute > 59 || minute < 0)
                {
                    return new ValidationResult(false, "0 - 59");
                }
                return new ValidationResult(true, null);
            }
            if (AppointmentFilter.FromHour == AppointmentFilter.ToHour)
                return new ValidationResult(false, AppointmentFilter.FromMinute + " - 59");
            else
                return new ValidationResult(false, "0 - 59");
        }
    }

    public class HourValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String; 
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

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

    public class ToHourValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (int.TryParse(val, out int hour))
            {
                if (hour > 23 || hour < Report.FromHour)
                {
                    return new ValidationResult(false, Report.FromHour + " - 23");
                }
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, Report.FromHour +  " - 23");
        }
    }

    public class ToHourFilterValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            String val = value as String;
            if (String.IsNullOrEmpty(val))
                return new ValidationResult(false, "Obavezno");

            if (int.TryParse(val, out int hour))
            {
                if (hour > 23 || hour < AppointmentFilter.FromHour)
                {
                    return new ValidationResult(false, AppointmentFilter.FromHour + " - 23");
                }
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, AppointmentFilter.FromHour + " - 23");
        }
    }
}
