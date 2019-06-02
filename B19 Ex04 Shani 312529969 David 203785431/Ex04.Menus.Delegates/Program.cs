using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MenuItem> listm = new List<MenuItem>() { new MenuItem("Dcd", null), new MenuItem("sss", null), new MenuItem("c", null) };
            MenuItem m = new MenuItem(listm, "sss");
            // Interface Menu
            MainMenu menu = new MainMenu();
            //menu.AddMenuItem("Show Date/Time");
            //menu.AddMenuItem("Version and Digits");
            //menu.AddMenuItem("Show Date", "Show Date/Time", new DateDisplayer());
            //menu.AddMenuItem("Show Time", "Show Date/Time", new TimeDisplayer());
            //menu.AddMenuItem("Count Digits", "Version and Digits", new DigitsCounter());
            //menu.AddMenuItem("Show Version", "Version and Digits", new VersionDisplayer());
            //menu.Show();
        }
    }
}
