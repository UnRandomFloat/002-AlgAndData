
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
                        Lesson1 L1 = new Lesson1();
                        L1.LessonMenu();
                        MainMenu.PrintMenu();
                        break;
                    case 2:
                        Console.Clear();
                        Lesson2 L2 = new Lesson2();
                        L2.LessonMenu();
                        MainMenu.PrintMenu();
                        break;
                    case 3:
                        Console.Clear();
                        Lesson3 L3 = new Lesson3();
                        L3.LessonMenu();
                        MainMenu.PrintMenu();
                        break;
                    case 4:
                        Console.Clear();
                        Lesson4 L4 = new Lesson4();
                        L4.LessonMenu();
                        Console.Clear();
                        MainMenu.PrintMenu();
                        break;
                    case 5:
                        Console.Clear();
                        Lesson5 L5 = new Lesson5();
                        L5.LessonMenu();
                        MainMenu.PrintMenu();
                        break;
                    case 6:
                        Console.Clear();
                        Lesson6 L6 = new Lesson6();
                        L6.LessonMenu();
                        MainMenu.PrintMenu();
                        break;
                    case 7:
                        Console.Clear();
                        Lesson7 L7 = new Lesson7();
                        L7.LessonMenu();
                        MainMenu.PrintMenu();
                        break;
                    case 100:
                        repit = false;
                        break;
                    default:
                        Console.WriteLine("Практическое задание к этому уроку еще неготово.");
                        Console.WriteLine("На данный момент выполнены практические задания урока №1,2,3,4,5,6");
                        repit = true;
                        break;
                }
            }
        }
    }
}
