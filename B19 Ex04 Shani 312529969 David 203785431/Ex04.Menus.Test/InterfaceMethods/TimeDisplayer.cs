using System;
using System.Collections.Generic;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class TimeDisplayer : IActionItem
    {
        public void DoAction()
        {
            Console.WriteLine("Time: {0}", DateTime.Now.ToString("HH:mm:ss"));
        }
    }
}
