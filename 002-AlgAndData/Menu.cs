using System;
using System.Collections.Generic;
using System.Text;

namespace Lessons
{
    /// <summary>
    /// Класс организации меню, вывода меню на консоль, и контроль соответствия выбраного значения
    /// </summary>
    public class Menu
    {
        public int FirstPoint { get; set; }
        public int LastPoint { get;  set; }
        public string Item { get; set; }
        public string Message { get; set; }
       public string ErrChoice { get; set; }
        public string[] Rows { get; set; }
        /// <summary>
        /// Класс для создания меню
        /// </summary>
        /// <param name="first">номер первого пункта меню</param>
        /// <param name="last">номер последнего пункта меню</param>
        /// <param name="item">Название пунктов</param>
        /// <param name="whatToChoice">Сообщение для корректного выбора</param>
        /// <param name="errChoice">Сообщение некорректного выбора</param>
        public Menu(int first, int last, string item, string whatToChoice, string errChoice)
        {
            FirstPoint = first;
            LastPoint = last;
            Item = item;
            Message = whatToChoice;
            ErrChoice = errChoice;
        }
        public Menu(string[] pointrows, string whatToChoice, string errChoice)
        {
            FirstPoint = 0;
            LastPoint = pointrows.Length-1;
            Rows = pointrows;
            Message = whatToChoice;
            ErrChoice = errChoice;
        }

        public void PrintMenu()// Вывод меню на консоль
        {
           
                if (Rows == null)
                {
                for (int i = FirstPoint; i <= LastPoint; i++)
                {
                    Console.WriteLine("{0} - {1} {0};", i, Item);
                }
                }
                else
                {
                for (int i = FirstPoint; i <= LastPoint; i++)
                {
                    Console.WriteLine(Rows[i] + ";");
                }
                }
            
        }

        
 
    }
}
