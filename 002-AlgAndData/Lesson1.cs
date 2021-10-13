using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace Lessons
{
    class Lesson1
    {
        public static void LessonMenu() // точка входа в практические задания к первому уроку!
        {
            ValidChoice VC = new ValidChoice();
            bool onemoretime = true;
            while (onemoretime)
            {
                Console.WriteLine("Урок №1. Блок-схемы, асимптотическая сложность, рекурсия");
                Console.WriteLine();
                Menu Lesson1Menu = new Menu(1, 3, "К заданию №", "Для просмотра введите номер задания или введите 100 для возврата в главное меню.", "Некорректное значение. Повторите ввод");
                Lesson1Menu.PrintMenu();

                switch (VC.FromMenu(Lesson1Menu))
                {
                    case 1:
                        Console.WriteLine("Давайте проверим, является введенное целое число простым?");
                        int n = VC.FromRandom(1, int.MaxValue, "Введите целое, положительное число", "Некорректное значение, повторите ввод");
                        isSimpleNumber(n);
                        onemoretime = true;
                        break;
                    case 2:
                        Asymptotic();
                        onemoretime = true;
                        break;
                    case 3:
                        int choice = VC.FromRandom(1, 2, "Введите номер 1 для расчета числа циклом или 2 для расчета рекурсией", "Некорректное значение, повторите ввод");
                        TestFibonach(choice);
                        break;
                    case 100:
                        onemoretime = false;
                        Console.Clear();
                        break;
                    default:
                        onemoretime = true;
                        break;
                }

            }
        }
        static void isSimpleNumber(int n)//проверка на простые числа
        {
            int d = 0;
            int i = 2;
            while (n > i)
            {
                if (n % i == 0)
                {
                    d++;
                    i++;
                }
                else
                {
                    i++;
                }
            }

            if (d == 0)
            {
                Console.WriteLine("Введенное число простое");
            }
            else
            {
                Console.WriteLine("Введенное число не простое");
            }

            Console.WriteLine("Задание завершено. Для продолжения нажмите Enter");
            Console.ReadLine();
            Console.Clear();
        }
        static void Asymptotic()//Надеюсь что правильно понял как считать надо
        {
            Console.WriteLine("Итого я насчитал О(8+N^3) или если принебречь то О(N^3)");
            Console.WriteLine();
            Console.WriteLine("Задание завершено. Для продолжения нажмите Enter");
            Console.ReadLine();
            Console.Clear();
        }
        static void TestFibonach(int choice)//метод ля расчета числа фибоначи двумя способами (Циклом и Рекурсией)
        {
            ValidChoice VC = new ValidChoice();
            int n = VC.FromRandom(1, 50, "Введите положительное целое число", "Некорректное значение. Повторите ввод");
            switch (choice)
            {
                case 1:
                    Cycle_Fibonach();
                    break;
                case 2:
                    Rec_Fibonach();
                    break;

            }

            void Cycle_Fibonach()//Расчет фибоначи циклом
            {
  
                double a = 0;
                double b = 1;
                double tmp;
                Stopwatch lookAtTheTime = new Stopwatch();
                lookAtTheTime.Start();
                for (int i = 0; i < n - 1; i++)
                {
                    tmp = a;
                    a = b;
                    b += tmp;
                }
                lookAtTheTime.Stop();

                Console.WriteLine($"Значение {n}-го числа Фибоначи, рассчитаное циклом - " + a) ;
                Console.WriteLine("Для этого понадобилось времени - "+lookAtTheTime.Elapsed);
                Console.WriteLine();
                Console.WriteLine("Задание завершено. Для продолжения нажмите Enter");
                Console.ReadLine();
                Console.Clear();

            }

            void Rec_Fibonach()
            { 
                Stopwatch lookAtTheTime = new Stopwatch();
                lookAtTheTime.Start();
                double result=Recursive_Fibonach(n);
                lookAtTheTime.Stop();
                Console.WriteLine($"Значение {n}-го числа Фибоначи, рассчитаное циклом - " + result);
                Console.WriteLine("Для этого понадобилось времени - " + lookAtTheTime.Elapsed);
                Console.WriteLine();
                Console.WriteLine("Задание завершено. Для продолжения нажмите Enter");
                Console.ReadLine();
                Console.Clear();

                double Recursive_Fibonach(int numb)//Расчет фибоначи рекурсией
                {
                
                    if (numb == 0)
                    {
                        return 0;
                    }
                    else if (numb == 1)
                    {
                        return 0;
                    }
                    else if (numb == 2)
                    {
                        return 1;
                    }
                    else
                    {
                        return Recursive_Fibonach(numb - 1) + Recursive_Fibonach(numb - 2);
                    }
                }
            }
        }
    }
}



