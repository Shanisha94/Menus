using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    internal class ActionItem : MenuItem
    {
        private IActionItem m_Action;
        
        public ActionItem(string i_Title, IActionItem i_Action, Dictionary<int, MenuItem> i_Parent) : base(i_Title, i_Parent)
        {
            m_Action = i_Action;
        }

        public ActionItem(string i_Title, IActionItem i_Action) : base(i_Title)
        {
            m_Action = i_Action;
        }

        public void Execute()
        {
            Console.Clear();
            m_Action.DoAction();
        }
    }
}
