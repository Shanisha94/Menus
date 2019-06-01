using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Interface Menu
            Interfaces.MainMenu menu = new MainMenu();
            menu.AddMenuItem("Show Date/Time");
            menu.AddMenuItem("Version and Digits");
            menu.AddMenuItem("Show Date", "Show Date/Time", new DateDisplayer());
            menu.AddMenuItem("Show Time", "Show Date/Time", new TimeDisplayer());
            menu.AddMenuItem("Count Digits", "Version and Digits", new DigitsCounter());
            menu.AddMenuItem("Show Version", "Version and Digits", new VersionDisplayer());
            menu.Show();
        }
    }
}
