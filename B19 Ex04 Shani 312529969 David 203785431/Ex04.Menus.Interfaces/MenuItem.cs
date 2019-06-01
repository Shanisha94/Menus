using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    internal class MenuItem
    {
        private const int k_BackIndex = 0;
        private const string k_Back = "Back";
        private readonly Dictionary<int, MenuItem> r_ParentMenu;
        private string m_Title;
        private Dictionary<int, MenuItem> m_ChildrenItems;

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

        public MenuItem()
        {
            m_ChildrenItems = new Dictionary<int, MenuItem>();
        }

        public MenuItem(string i_Title, Dictionary<int, MenuItem> i_Parent = null)
        {
            m_ChildrenItems = new Dictionary<int, MenuItem>();
            m_Title = i_Title;
            if (i_Parent != null)
            {
                r_ParentMenu = i_Parent;
            }
        }

        public void AddChild(MenuItem i_Child)
        {
            if (m_ChildrenItems.Count == 0)
            {
                MenuItem back = new MenuItem(k_Back);
                m_ChildrenItems[k_BackIndex] = back;
            }

            m_ChildrenItems[m_ChildrenItems.Count] = i_Child;
        }
    }
}
