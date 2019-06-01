using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private const int k_BackOrExitIndex = 0;
        private const string k_Back = "Back";
        private const string k_Exit = "Exit";        
        private Dictionary<int, MenuItem> m_MenuTree;

        public MainMenu()
        {
            m_MenuTree = new Dictionary<int, MenuItem>();
            MenuItem exitItem = new MenuItem(k_Exit);
            m_MenuTree[k_BackOrExitIndex] = exitItem;
        }

        public void Show()
        {
            string title = "Welcome! Please choose an item from the menu";
            Dictionary<int, MenuItem> currentLevel = m_MenuTree;
            printCurrentLevel(m_MenuTree, title);
            getUserChoice(currentLevel, out int userChoice);
            while (!(userChoice == k_BackOrExitIndex && currentLevel == m_MenuTree))
            {
                Console.Clear();
                if (userChoice == k_BackOrExitIndex)
                {
                    title = k_Back;
                    currentLevel = currentLevel[1].Parent;
                }
                else if (currentLevel[userChoice].Children.Count == 0)
                {
                    ((ActionItem)currentLevel[userChoice]).Execute();
                }
                else
                {
                    title = currentLevel[userChoice].Title;
                    currentLevel = currentLevel[userChoice].Children;
                }

                printCurrentLevel(currentLevel, title);
                getUserChoice(currentLevel, out userChoice);
            }

            Console.Clear();
        }

        private void printCurrentLevel(Dictionary<int, MenuItem> i_CurrentLevel, string i_Title)
        {
            StringBuilder buildMenu = new StringBuilder();
            buildMenu.AppendFormat("{0}{1}", i_Title, Environment.NewLine);
            foreach (KeyValuePair<int, MenuItem> item in i_CurrentLevel)
            {
                buildMenu.AppendFormat("{0}. {1}{2}", item.Key, item.Value.Title, Environment.NewLine);
            }

            Console.WriteLine(buildMenu);
        }

        private void getUserChoice(Dictionary<int, MenuItem> i_CurrentLevel, out int o_UserChoice)
        {
            Console.WriteLine("Please choose an item from the menu:");
            string input = Console.ReadLine();
            if (!isValidInput(i_CurrentLevel, input, out o_UserChoice))
            {
                Console.WriteLine("Invalid input, please try again...");
                getUserChoice(i_CurrentLevel, out o_UserChoice);
            }
        }

        private bool isValidInput(Dictionary<int, MenuItem> i_CurrentLevel, string i_Input, out int o_UserChoice)
        {
            int numOfItems = i_CurrentLevel.Count;
            bool isValid = false;

            if (int.TryParse(i_Input, out o_UserChoice))
            {
                isValid = o_UserChoice >= k_BackOrExitIndex && o_UserChoice <= numOfItems;
            }

            return isValid;
        }

        public void AddMenuItem(string i_ItemTitle, string i_ParentItem = "", object i_Action = null)
        {
            if (i_ParentItem == string.Empty)
            { // add to root level
                if (i_Action == null)
                {
                    m_MenuTree[m_MenuTree.Count] = new MenuItem(i_ItemTitle);
                }
                else
                {
                    IActionItem action = i_Action as IActionItem;
                    if (action != null)
                    {
                        m_MenuTree[m_MenuTree.Count] = new ActionItem(i_ItemTitle, action);
                    }
                }
            }
            else
            {
                Dictionary<int, MenuItem> parentMenu = getParentMenu(i_ParentItem);
                MenuItem parentItem = getParentItem(i_ParentItem, parentMenu);
                if (parentMenu != null)
                {
                    if (i_Action == null)
                    {
                        parentItem.AddChild(new MenuItem(i_ItemTitle, parentMenu));
                    }
                    else
                    {
                        IActionItem action = i_Action as IActionItem;
                        if (action != null)
                        {
                            parentItem.AddChild(new ActionItem(i_ItemTitle, action, parentMenu));
                        }
                    }
                }
            }       
        }

        private Dictionary<int, MenuItem> getParentMenu(string i_ItemInMenu)
        {
            Dictionary<int, MenuItem> subMenu = null;

            foreach (KeyValuePair<int, MenuItem> item in m_MenuTree)
            {
                if (item.Value.Title == i_ItemInMenu)
                {
                    subMenu = m_MenuTree;
                    break;
                }

                foreach (KeyValuePair<int, MenuItem> childItem in item.Value.Children)
                {
                    if (childItem.Value.Title == i_ItemInMenu)
                    {
                        subMenu = item.Value.Children;
                        break;
                    }
                }
            }

            return subMenu;
        }

        private MenuItem getParentItem(string i_ItemInMenu, Dictionary<int, MenuItem> i_SubMenu)
        {
            MenuItem parentItem = null;

            foreach (KeyValuePair<int, MenuItem> item in i_SubMenu)
            {
                if (item.Value.Title == i_ItemInMenu)
                {
                    parentItem = item.Value;
                    break;
                }
            }

            return parentItem;
        }
    }
}
