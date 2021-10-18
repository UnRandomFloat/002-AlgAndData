
using System;

namespace Lessons
{
    /// <summary>
    /// Класс для организации главного меню и передачи управления в соотвтетствующий раздел.
    /// </summary>
    public class Dispetcher
    {
        bool repit = true;
        public Menu MainMenu;
        ValidChoice VC = new ValidChoice();
        public Dispetcher(int first, int last, string item, string whatToChoice, string errChoice)
        {
            MainMenu = new Menu(first, last, item, whatToChoice, errChoice);
        }
        public void TransferControlToLesson()
        {
            MainMenu.PrintMenu();
            while (repit)
            {
                switch (VC.FromMenu(MainMenu))
                {
                    case 1:
                        Console.Clear();
                        Lesson1.LessonMenu();
                        MainMenu.PrintMenu();
                        break;
                    case 2:
                        Console.Clear();
                        Lesson2.LessonMenu();
                        MainMenu.PrintMenu();
                        break;
                    case 3:
                        Console.Clear();
                        Lesson3.LessonMenu();
                        MainMenu.PrintMenu();
                        break;
                    case 4:
                        Console.Clear();
                        Lesson4.LessonMenu();
                        Console.Clear();
                        MainMenu.PrintMenu();
                        break;
                    case 5:
                        Console.Clear();
                        Lesson5.LessonMenu();
                        MainMenu.PrintMenu();
                        break;
                    case 100:
                        repit = false;
                        break;
                    default:
                        Console.WriteLine("Практическое задание к этому уроку еще неготово.");
                        Console.WriteLine("На данный момент выполнены практические задания урока №1,2,3,4,5");
                        repit = true;
                        break;
                }
            }
        }
    }
}
