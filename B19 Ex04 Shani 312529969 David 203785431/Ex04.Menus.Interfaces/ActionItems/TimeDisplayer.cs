using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces.ActionItems
{
    public class TimeDisplayer : IActionItem
    {
        public void DoAction()
        {
            Console.WriteLine("Time: {0}", DateTime.Now.ToString("HH:mm:ss"));
        }
    }
}
