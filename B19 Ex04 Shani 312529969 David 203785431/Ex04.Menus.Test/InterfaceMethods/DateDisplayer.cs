using System;
using System.Collections.Generic;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class DateDisplayer : IActionItem
    {
        public void DoAction()
        {
            Console.WriteLine("Date: {0}", DateTime.Now.ToString("MM/dd/yyyy"));
        }
    }
}
