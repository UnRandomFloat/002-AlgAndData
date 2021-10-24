using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class Lesson6
    {
        public static void LessonMenu()
        {
            string[] menuRows ={
                "0 - Создать Граф для тестирования обхода BFS & DFS", //(если пропустить этот шаг, будет создан(или нет) граф со случайными числами)?,
                "1 - Тестируем обход графа BFS",
                "2 - Тестируем обход графа DFS"
            };
            Menu Lesson6Menu = new Menu(menuRows, "Выбирите пункт меню или введите 100 для возрата в предыдущее", "Некорректное значение. Повторите ввод.");
            ValidChoice VC = new ValidChoice();
            Graph EG=new Graph();

            int datatoFind;
            bool onemoretime = true;
            BFS Bfs = new BFS();
            DFS Dfs = new DFS();
            while (onemoretime)
            {
                Lesson6Menu.PrintMenu();
                int choice = VC.FromMenu(Lesson6Menu);
                switch (choice)
                {
                    case 0:
                        EG=EG.GraphCreator();
                        Console.Clear();
                        foreach (GraphNode GN in EG.Nodes)
                        {
                            Console.WriteLine(GN.Name);
                        }
                        menuRows[0] = "Граф создан выбирите дальнейшие дествия";
                        break;
                    case 1:
                        Console.Clear();
                        Bfs.Graph_BFS(EG);
                        Console.WriteLine("Результат обхода графа в ширину. Enter для продолжения");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Dfs.Graph_DFS(EG);
                        Console.WriteLine("Результат обхода графа в глубину. Enter для продолжения");
                        Console.ReadLine();
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
