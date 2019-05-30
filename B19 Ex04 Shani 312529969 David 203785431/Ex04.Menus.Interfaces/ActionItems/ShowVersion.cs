using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces.ActionItems
{
    class ShowVersion : IActionItem
    {
        public void DoAction()
        {
            Console.WriteLine("Version: 19.2.4.32");
        }
    }
}
