using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces.ActionItems
{
    class ShowDate : IActionItem
    {
        public void DoAction()
        {
            Console.WriteLine(DateTime.Now.ToString("MM/dd/yyyy"));
        }
    }
}
