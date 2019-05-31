using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces.ActionItems
{
    public class DateDisplayer : IActionItem
    {
        public void DoAction()
        {
            Console.WriteLine("Date: {0}", DateTime.Now.ToString("MM/dd/yyyy"));
        }
    }
}
