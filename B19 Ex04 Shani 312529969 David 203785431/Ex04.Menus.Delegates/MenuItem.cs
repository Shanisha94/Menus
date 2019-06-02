using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    class MenuItem
    {
        internal event Action DoYourJob;
        internal event Action GetToPrevMenu;
        private string m_Text;
        private List<MenuItem> m_ChildrenItems;

        public MenuItem(string i_Text, IActionItem i_Functionality)
        {
            m_Text = i_Text;
            if (i_Functionality != null)
            {
                DoYourJob += i_Functionality.DoAction;
            }
        }
        public MenuItem(List<MenuItem> i_ChildrenItems, string i_Text)
        {
            m_Text = i_Text;
            initChildItems();
            if (i_ChildrenItems != null)
            {
                m_ChildrenItems.AddRange(i_ChildrenItems);
            }
        }
        public List<MenuItem> ChildrenItems
        {
            get
            {
                return m_ChildrenItems;
            }
        }
        public string Text
        {
            set
            {
                m_Text = value;
            }
            get
            {
                return m_Text;
            }
        }
        public void RunSubMenu()
        {
            ShowSubMenu();
            int choise = getUserInput();
            m_ChildrenItems[choise].DoMyJob();
        }
        private int getUserInput()
        {
            string stringInput = Console.ReadLine();
            int intInput;
            while (!int.TryParse(stringInput, out intInput) || intInput < 0 || intInput > m_ChildrenItems.Count)
            {
                Console.WriteLine(string.Format("Invalid input, please enter only numbers between 0 and {0}", m_ChildrenItems.Count));
                stringInput = Console.ReadLine();
            }
            return intInput;
        }
        internal void ShowSubMenu()
        {
            Console.Clear();
            StringBuilder textToPrint = new StringBuilder();
            textToPrint.AppendFormat("{0}{1}", this.m_Text, Environment.NewLine);
            int itemNumber = 0;
            foreach (MenuItem item in m_ChildrenItems)
            {
                textToPrint.AppendFormat("{0}. {1}{2}", itemNumber, item.m_Text, Environment.NewLine);
                itemNumber++;
            }
            textToPrint.AppendFormat("Please Enter the number of the option you want to select{0}", Environment.NewLine);
            Console.WriteLine(textToPrint);
        }


        public void AddChildItem(MenuItem i_ChildrenItem)
        {
            if (m_ChildrenItems == null)
            {
                initChildItems();
            }
            if (i_ChildrenItem != null)
            {
                m_ChildrenItems.Add(i_ChildrenItem);
            }
        }

        private void initChildItems()
        {
            m_ChildrenItems = new List<MenuItem>();
            m_ChildrenItems.Add(new MenuItem("Back", null));
            m_ChildrenItems[0].GetToPrevMenu = this.ShowSubMenu;
        }

        internal void DoMyJob()
        {
            if (DoYourJob != null)
            {
                DoYourJob.Invoke();
                if (GetToPrevMenu!=null)
                {
                    GetToPrevMenu.Invoke();
                }
            }
            else if (m_ChildrenItems != null)
            {
                ShowSubMenu();
            }

        }
    }
}
