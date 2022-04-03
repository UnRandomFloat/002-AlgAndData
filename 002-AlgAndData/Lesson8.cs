using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class Lesson8
    {
        public void LessonMenu()
        {
            string[] menuRows ={
                "0 - Создать массив случайным размером(от 50 до 100 элементов) со случайными числами", 
                "1 - Вывести исходный массив",
                "2 - Отсортировать созданный масиив методом Bucketsort",
                "3 - Вывести отсортированный массив",
            };
            Menu Lesson8Menu = new Menu(menuRows, "Выбирите пункт меню или введите 100 для возрата в предыдущее", "Некорректное значение. Повторите ввод.");
            ValidChoice VC = new ValidChoice();
            int[] primalArray = null;
            int[] afterSortArray = null;
            bool onemoretime = true;
            while (onemoretime)
            {
                Lesson8Menu.PrintMenu();
                int choice = VC.FromMenu(Lesson8Menu);
                switch (choice)
                {
                    case 0:
                        primalArray = ArrayCreator();
                        break;

                    case 1:
                        if (primalArray == null)
                        {
                            Console.WriteLine("Для начала создаем массив:");
                            primalArray = ArrayCreator();
                        }
                        PrintArray(primalArray);
                        break;
                    case 2:
                        if (primalArray == null)
                        {
                            Console.WriteLine("Для начала будет создан массив:");
                            primalArray = ArrayCreator();
                        }
                       afterSortArray=ArrayBucketSort(primalArray);
                        break;
                    case 3:
                        if (primalArray == null && afterSortArray == null)
                        {
                            Console.WriteLine("Для начала будет создан массив:");
                            primalArray = ArrayCreator();
                            Console.WriteLine("Теперь исходный массив будет отсортирован:");
                            afterSortArray = ArrayBucketSort(primalArray);
                        }
                        if (primalArray == null)
                        {
                            Console.WriteLine("Для начала будет создан массив:");
                            primalArray = ArrayCreator();
                        }
                        else if (afterSortArray == null)
                        {
                            Console.WriteLine("Для начала исходный массив будет отсортирован:");
                            afterSortArray = ArrayBucketSort(primalArray);
                        }
                        PrintArray(afterSortArray);
                        break;
                    case 100:
                        onemoretime = false;
                        break;
                }
            }
        }
        public int[] ArrayCreator()
        {
         
            int lenArray = new Random().Next(50, 100);
            int[] created = new int[lenArray];
            for (int i = 0; i < created.Length; i++)
            {
                created[i]= new Random().Next(1, 99);
            }
            Console.WriteLine($"Создан массив со случайными числами, на {created.Length} элементов. Для продолжения нажмите Enter.");
            Console.ReadLine();
            Console.Clear();
            return created;
        }
        void PrintArray(int[] arrayToPrint)
        {
            Console.WriteLine("Элементы массива:");
            foreach (var item in arrayToPrint)
            {
                Console.Write(item +", ");
                
            }
            Console.WriteLine("\n Enter для продолжения");
            Console.ReadLine();
            Console.Clear();
        }

        public int[] ArrayBucketSort(int[] arrayToSort)
        {
            {
             
                List<int>[] created = new List<int>[arrayToSort.Length];

            
                for (int i = 0; i < created.Length; ++i)
                    created[i] = new List<int>();

            
                int minimal = arrayToSort.Min();
                int maximum = arrayToSort.Max();

                double saved = maximum - minimal;

                for (int i = 0; i < arrayToSort.Length; ++i)
                {
                    int bucketnum = (int)Math.Floor((arrayToSort[i] - minimal) / saved * (created.Length - 1));
                    created[bucketnum].Add(arrayToSort[i]);
                }
                for (int i = 0; i < created.Length; ++i)
                    created[i].Sort();

                int idx = 0;

                for (int i = 0; i < created.Length; ++i)
                {
                    for (int j = 0; j < created[i].Count; ++j)
                        arrayToSort[idx++] = created[i][j];
                }
                Console.WriteLine("\n Массив отсортирован. Enter для продолжения");
                Console.ReadLine();
                Console.Clear();
                return arrayToSort;


            }
        }
    }
}
