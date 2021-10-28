using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class Lesson5
    {
        public void LessonMenu()
        {
            string[] menuRows ={
                "0 - Создать дерево для тестирования обхода BFS & DFS (если пропустить этот шаг, будет создано дерево со случайными числами)",
                "1 - Тестируем обход дерева BFS",
                "2 - Тестируем обход дерева DFS"
            };
            Menu Lesson5Menu = new Menu(menuRows, "Выбирите пункт меню или введите 100 для возрата в предыдущее", "Некорректное значение. Повторите ввод.");
            ValidChoice VC = new ValidChoice();
            BinaryTree BT=null; //= Lesson4.BinaryTreeSearch();
            Lesson4 L4 = new Lesson4();
            int datatoFind;
            bool onemoretime = true;
            BFS Bfs = new BFS();
            DFS Dfs = new DFS();
            while (onemoretime)
            {
                Lesson5Menu.PrintMenu();
                int choice = VC.FromMenu(Lesson5Menu);
                switch (choice)
                {
                    case 0:
                        BT = L4.BinaryTreeSearch();
                        BT.PrintTree();
                        Console.WriteLine("Дерево заполнено. Для продолжения нажмите Enter.");
                        Console.ReadLine();
                        break;
                    case 1:
      
                        if (BT == null)
                        {
                            BT = L4.RandomTree(11);
                            datatoFind = VC.FromRandom(5, 20, "Введите искомое целое число.");
                        }
                        else
                        {
                            datatoFind = VC.FromRandom(5, int.MaxValue, "Введите искомое целое число.");
                        }
                        Bfs.BreadthFirstSearch(datatoFind, BT.Root);
                        break;
                    case 2:
                        if (BT == null)
                        {
                            BT = L4.RandomTree(11);
                            datatoFind = VC.FromRandom(5, 20, "Введите искомое целое число.");
                        }
                        else
                        {
                            datatoFind = VC.FromRandom(5, int.MaxValue, "Введите искомое целое число.");
                        }
                        Dfs.DeepFirstSearch(datatoFind, BT.Root);
                        break;
                    case 100:
                        onemoretime = false;
                        break;
                    default:
                        break;
            
                }
            }


        }
    }
}
