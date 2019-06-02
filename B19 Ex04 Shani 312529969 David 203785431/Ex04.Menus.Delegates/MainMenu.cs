using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    class MainMenu
    {

        private List<MenuItem> m_FirstLevel;
        private void exitMainMenu()
        {
            Environment.Exit(0);
        }
        public MainMenu()
        {
            m_FirstLevel = new List<MenuItem>();
            MenuItem exit = new MenuItem(null, "Exit");
            exit.DoYourJob += exitMainMenu;
        }
        public void AddMenuItem(MenuItem i_MenuItem)
        {
            if (i_MenuItem != null)
            {
                m_FirstLevel.Add(i_MenuItem);
            }
        }
       
      
    }
}
