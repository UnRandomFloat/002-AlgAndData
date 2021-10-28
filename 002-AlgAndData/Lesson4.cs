using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    public class Lesson4
    {
        public void LessonMenu()
        {
            bool onemoretime = true;
            while (onemoretime)
            {
                string[] menuRows =
                {
                "0 - Тест поиcка строки в масcиве и HashSet;",
                "1 - Реализация двоичного дерева поиска и вывод на консоль",
                };
                Console.WriteLine("Урок 4. Деревья, хэш-таблицы");
                Console.WriteLine();

                Menu Lesson4Menu = new Menu(menuRows, "Для просмотра введите номер задания или введите 100 для возврата в главное меню.", "Некорректное значение. Повторите ввод");
                Lesson4Menu.PrintMenu();
                ValidChoice VC = new ValidChoice();
                int choice = VC.FromMenu(Lesson4Menu);
                switch (choice)
                {
                    case 0:
                        ArrayHashSetCompare();
                        Console.Clear();
                        break;
                    case 1:
                        Console.Clear();
                        BinaryTreeSearch();
                        Console.Clear();
                        break;
                    case 100:
                        onemoretime = false;
                        break;
                    default:
                        break;

                }
            }
        }
         void ArrayHashSetCompare()
        {
            Console.WriteLine("Тест поиcка строки в масcиве и HashSet:");
            Console.WriteLine();
            Stopwatch sw = new Stopwatch();
            ValidChoice VC = new ValidChoice();
            int n = VC.FromRandom(100, int.MaxValue - 100, "Введите количество строк для заполнения массива и HashSet", "Некорректное значение. Повторите ввод");
            string[] randomStrings = new string[n];
            HashSet<string> HS = new HashSet<string>();
            for (int i = 0; i < n - 1; i++)
            {
                Random unexpected = new Random();
                char[] literals = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                int ran1 = unexpected.Next(0, literals.Length - 1);
                int ran2 = unexpected.Next(0, literals.Length - 1);
                int ran3 = unexpected.Next(0, literals.Length - 1);


                string str = new String(new char[] { literals[ran1], literals[ran2], literals[ran3] });
                randomStrings[i] = str;
                HS.Add(str);
            }
            Console.WriteLine($"HashSet и массив заполнены {n} строками (состоящими из 3х латинских букв в верхнем регистре");
            Console.WriteLine("Давайте сравним поиск строки по массиву и поиск по HashSet... Введите строку, состоящую из трех заглавных английских букв");
            string findout = Console.ReadLine();
            bool isfind = false;
            sw.Start();
            for (int i = 0; i < randomStrings.Length - 1; i++)
            {
                if (randomStrings[i] == findout)
                {
                    isfind = true;
                    Console.WriteLine("В массиве искомое значение найдено!!!");
                    break;
                }

            }
            sw.Stop();
            Console.WriteLine(!isfind ? "Значение в массиве не найдено!!!" : "");
            Console.WriteLine("Времени на поиск по массиву затрачено - " + sw.Elapsed);
            Console.WriteLine("Давайте теперь поищем это же значение в HashSet. Для продолжения нажмите Enter");
            Console.ReadLine();
            sw.Restart();

            if (HS.Contains(findout))
            {
                sw.Stop();

                Console.WriteLine("В HashSet искомое значение найдено!!!");
            }
            else
            {
                sw.Stop();
                Console.WriteLine("Значение в HashSet не найдено!!!");
            }
            Console.WriteLine("Времени на поиск по HashSet затрачено - " + sw.Elapsed);
            Console.WriteLine(Guid.NewGuid().ToString());
            Console.ReadLine();

        }
        public  BinaryTree BinaryTreeSearch()
        {
            BinaryTree BTree = new BinaryTree();
            string[] menuRows =
                {
                "0- Получить корень дерева",
                "1- Добавить узел в дерево",
                "2- Удалить узел по значению",
                "3- Получить узел по значению",
                "4- Вывести дерево в консоль",
                "5- Выход в предыдущее меню (а так же возврат заполненного дерева)"
            };
           Menu binaryTreeMenu = new Menu(menuRows, "Выберите пункт меню","Некорректное значение. Повторите ввод");
            ValidChoice VC = new ValidChoice();
            bool onemoretime = true;
            while (onemoretime)
            {
                binaryTreeMenu.PrintMenu();
                int choice = VC.FromMenu(binaryTreeMenu);
                switch (choice)
                {
                    case 0:
                        string message = BTree.GetRoot() == null ? "У дерева нет корня" : $"Корень дерева  - {BTree.GetRoot().Data}";
                        Console.WriteLine(message);
                        repit();
                       break;
                    case 1:
                        BTree.AddItem(VC.FromRandom(0, int.MaxValue - 10, "Введите значение которое нужно добавить", "Некорректное значение. Повторите ввод"));
                        repit();
                        break;
                    case 2:
                        BTree.RemoveItem(VC.FromRandom(0, int.MaxValue - 10, "Введите значение которое нужно удалить", "Некорректное значение. Повторите ввод"));
                        repit();
                        break;
                    case 3:
                        BTree.GetNodeByValue(VC.FromRandom(0, int.MaxValue - 10, "Введите значение которое нужно найти", "Некорректное значение. Повторите ввод"));
                        repit();
                        break;
                    case 4:
                        BTree.PrintTree();
                        repit();
                        break;
                    case 5:
                        onemoretime = false;
                        break;
                    dafault:
                        break;

                }
               // return BTree;
            }
            
            void repit()
            {
                Console.WriteLine("Enter для продолжения");
                Console.ReadLine();
                Console.Clear();
            }
            return BTree;
        }
        public  BinaryTree RandomTree(int n)
        {
           
            BinaryTree BT = new BinaryTree();
            BT.AddItem(n);
            for (int i = 1; i < n; i++)
            {
          
                BT.AddItem(new Random().Next(n-(n-1), n-1));
             
            }
            return BT;
        }


    }
}
