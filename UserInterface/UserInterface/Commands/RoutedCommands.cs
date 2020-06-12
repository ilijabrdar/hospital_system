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
    }
}
