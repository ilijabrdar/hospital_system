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
        public static readonly RoutedUICommand EnterCommand = new RoutedUICommand(
          "Log an user in", "Login", typeof(RoutedCommand), new InputGestureCollection() { new KeyGesture(Key.Enter) });

        public static readonly RoutedUICommand EscCommand = new RoutedUICommand(
            "Escape from table", "Escape", typeof(RoutedCommand), new InputGestureCollection() { new KeyGesture(Key.Escape) });

        public static readonly RoutedUICommand ProfileTab = new RoutedUICommand(
    "Go to Profile tab", "Profile", typeof(RoutedCommand), new InputGestureCollection() { new KeyGesture(Key.P, ModifierKeys.Control) });

        public static readonly RoutedUICommand ExaminationTab = new RoutedUICommand(
    "Go to examinations", "Examinations", typeof(RoutedCommand), new InputGestureCollection() { new KeyGesture(Key.E, ModifierKeys.Control) });

        public static readonly RoutedUICommand NewPatientTab = new RoutedUICommand(
    "Add new patient", "New patient", typeof(RoutedCommand), new InputGestureCollection() { new KeyGesture(Key.N, ModifierKeys.Control) });

        public static readonly RoutedUICommand HelpTab = new RoutedUICommand(
    "Get help", "Help", typeof(RoutedCommand), new InputGestureCollection() { new KeyGesture(Key.H, ModifierKeys.Control), new KeyGesture(Key.F1) });

        public static readonly RoutedUICommand FeedbackTab = new RoutedUICommand(
    "Give feedback", "Feedback", typeof(RoutedCommand), new InputGestureCollection() { new KeyGesture(Key.U, ModifierKeys.Control) });
    }
}
