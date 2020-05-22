using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserInterface.Commands
{
    public static class RoutedCommands
    {
        public static readonly RoutedUICommand OpenEditPanel = new RoutedUICommand(
            "Opens Profile Changing Panel", "ChangeProfile", typeof(RoutedCommand), new InputGestureCollection() { new KeyGesture(Key.E, ModifierKeys.Alt) });

        public static readonly RoutedUICommand FindAppointment = new RoutedUICommand(
            "Opens Appointment Filter Dialog", "FindAppointment", typeof(RoutedCommand), new InputGestureCollection() { new KeyGesture(Key.F) });

        public static readonly RoutedUICommand GenerateReport = new RoutedUICommand(
           "Opens Appointment Filter Dialog", "GenerateReport", typeof(RoutedCommand), new InputGestureCollection() { new KeyGesture(Key.I, ModifierKeys.Alt) });
    }
}
