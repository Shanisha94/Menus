using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces.ActionItems
{
    public class DigitsCounter : IActionItem
    {
        public void DoAction()
        {
            Console.WriteLine("Write a sentence: ");
            string input = Console.ReadLine();
            int numOfDigits = countDigits(input);
            Console.WriteLine("There are {0} digits in the sentence", numOfDigits);
        }

        private int countDigits(string i_Input)
        {
            int counter = 0;
            foreach(char character in i_Input)
            {
                if(char.IsDigit(character))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
