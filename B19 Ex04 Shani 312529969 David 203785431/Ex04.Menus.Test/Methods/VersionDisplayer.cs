using System;
using System.Collections.Generic;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class VersionDisplayer : IActionItem
    {
        public void DoAction()
        {
            Console.WriteLine("Version: 19.2.4.32");
        }
    }
}
