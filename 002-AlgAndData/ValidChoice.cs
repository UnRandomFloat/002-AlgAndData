using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessons
{
    class ValidChoice
    {
        public int FromMenu(Menu menu)//контроль выбранного значения из переданного меню
        {

            return FromRandom(menu.FirstPoint, menu.LastPoint, menu.Message, menu.ErrChoice);
        }

        /// <summary>
        /// Контроль выбираемого значения
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="whatToChoice"></param>
        /// <param name="errChoice"></param>
        /// <returns>int чило выбранное в соответсвии с критериями</returns>
        public int FromRandom(int first, int last, string whatToChoice, string errChoice)
        {
            Console.WriteLine("{0} (от {1} до {2})", whatToChoice, first, last);
            int numChoice = 0;
            string getNumb = Console.ReadLine();
            while (!int.TryParse(getNumb, out numChoice) || numChoice < first || numChoice > last)
            {
                if (numChoice == 100)
                {
                    return numChoice;
                }
                Console.WriteLine("{0} (от {1} до {2})", errChoice, first, last);
                getNumb = Console.ReadLine();
            }
            return numChoice;
        }
    }
}
