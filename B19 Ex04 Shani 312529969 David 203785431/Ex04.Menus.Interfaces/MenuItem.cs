using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class MenuItem
    {
        private const int k_BackIndex = 0;
        private const string k_Back = "Back";
        private string m_Title;
        private Dictionary<int, MenuItem> m_ChildrenItems;
        private readonly Dictionary<int, MenuItem> r_ParentMenu;

        public string Title
        {
            get
            {
                return m_Title;
            }

            set
            {
                m_Title = value;
            }
        }

        public Dictionary<int, MenuItem> Children
        {
            get
            {
                return m_ChildrenItems;
            }

            set
            {
                m_ChildrenItems = value;
            }
        }

        public Dictionary<int, MenuItem> Parent
        {
            get
            {
                return r_ParentMenu;
            }
        }

        public MenuItem(string i_Title)
        {
            m_ChildrenItems = new Dictionary<int, MenuItem>();
            r_ParentMenu = new Dictionary<int, MenuItem>();
            m_Title = i_Title;
        }

        public MenuItem(string i_Title, Dictionary<int, MenuItem> i_Parent)
        {
            m_ChildrenItems = new Dictionary<int, MenuItem>();
            m_Title = i_Title;
            r_ParentMenu = i_Parent;
        }

        public void AddChild(MenuItem i_Child)
        {
            m_ChildrenItems[m_ChildrenItems.Count + 1] = i_Child;
        }
    }
}
