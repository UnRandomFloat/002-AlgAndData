using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    public class Lesson7
    {
        public void LessonMenu()
        {
            string[] menuRows ={
                "0 - Задать(или изменить) размеры поля для расчета максимального количества ходов", //(если пропустить этот шаг, будет создан(или нет) граф со случайными числами)?,
                "1 - Рассчет первым методом (как в методичке)",
                "2 - Расчет вторым методом (сам придумал)",
                "3 - Расчет еще одним методом",
            };
            Menu Lesson7Menu = new Menu(menuRows, "Выбирите пункт меню или введите 100 для возрата в предыдущее", "Некорректное значение. Повторите ввод.");
            ValidChoice VC = new ValidChoice();
            int[,] Tabl = null;
            bool onemoretime = true;

            while (onemoretime)
            {
                Lesson7Menu.PrintMenu();
                int choice = VC.FromMenu(Lesson7Menu);
                switch (choice)
                {
                    case 0:
                        Tabl = TablCreator();
                        Console.WriteLine($"Создано поле размером: {Tabl.GetLength(0)} x {Tabl.GetLength(1)}");
                        break;
                    case 1:
                        if (Tabl == null)
                        {
                            Console.WriteLine("Для начала задайте размер поля!");
                            Tabl = TablCreator();
                        }
                        Methood1(Tabl);
                        break;
                    case 2:
                        if (Tabl == null)
                        {
                            Console.WriteLine("Для начала задайте размер поля!");
                            Tabl = TablCreator();
                        }
                        Methood2(Tabl);
                        break;
                    case 3:
                        if (Tabl == null)
                        {
                            Console.WriteLine("Для начала задайте размер поля!");
                            Tabl = TablCreator();
                        }
                        Methood3(Tabl);
                        break;
                    case 100:
                        onemoretime = false;
                        break;
                }
            }
        }
        int[,] TablCreator()
        {
            ValidChoice VC = new ValidChoice();
            int N = VC.FromRandom(1, 25, "Введите высоту поля (по оси У)");//высота
            int M = VC.FromRandom(1, 25, "Введите ширину поля (по оси Х)");//ширина поля
            int[,] tab = new int[N, M];
            return tab;
        }
        void Methood1(int[,] tabl)// расчет с помощью методички
        {

            int[,] A = tabl;
            int i, j;
            Stopwatch SW = new Stopwatch();
            SW.Start();
            for (j = 0; j < A.GetLength(1); j++)
                A[0, j] = 1; // Первая строка заполнена единицами
            for (i = 1; i < A.GetLength(0); i++)
            {
                A[i, 0] = 1;
                for (j = 1; j < A.GetLength(1); j++)
                    A[i, j] = A[i, j - 1] + A[i - 1, j];
            }
            SW.Stop();
            Console.WriteLine($"Алгоритм завершен расчитано количество шагов {A[A.GetLength(0) - 1, A.GetLength(1) - 1]}");
            Console.WriteLine($"Время выполнения - {SW.Elapsed}. Enter для продолжения");
            Console.ReadLine();

        }
        void Methood2(int[,] tabl)// расчет мной придуманым способом
        {
            Stopwatch SW = new Stopwatch();
            SW.Start();
            for (int i = 0; i < tabl.GetLength(0); i++)//строки
            {
                for (int j = 0; j < tabl.GetLength(1); j++)//столбцы
                {
                    if (i == 0 || j == 0)
                    {
                        tabl[i, j] = 1;
                    }
                    else
                    {
                        tabl[i, j] = tabl[i, j - 1] + tabl[i - 1, j];
                    }

                }
            }
            SW.Stop();
            Console.WriteLine($"Алгоритм завершен расчитано количество шагов {tabl[tabl.GetLength(0) - 1, tabl.GetLength(1) - 1]}");
            Console.WriteLine($"Время выполнения - {SW.Elapsed}. Enter для продолжения");
            Console.ReadLine();
        }
        void Methood3(int[,] tabl)// как тебе такое Илон?=))) получается самый быстрый до 5 раз быстрее!
        {
            Stopwatch SW = new Stopwatch();
            SW.Start();
            double steps = faktorial((tabl.GetLength(0) - 1) + (tabl.GetLength(1) - 1)) / (faktorial(tabl.GetLength(0) - 1) * faktorial(tabl.GetLength(1) - 1));
            SW.Stop();
            Console.WriteLine($"Алгоритм завершен расчитано количество шагов {steps}");
            Console.WriteLine($"Время выполнения - {SW.Elapsed}. Enter для продолжения");
            Console.ReadLine();
        }
        double faktorial(int n)
        {
            double factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
