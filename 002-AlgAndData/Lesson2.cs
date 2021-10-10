using System;
using System.Collections;

namespace Lessons
{
    class Lesson2
    {
        public static void LessonMenu()
        {
            bool onemoretime = true;
            while (onemoretime)
            {
                Console.WriteLine("Урок №2. Массив, список, поиск");
                Console.WriteLine();
                ValidChoice VC = new ValidChoice();
                Menu Lesson2Menu = new Menu(1, 2, "К заданию №", "Для просмотра введите номер задания или введите 100 для возврата в главное меню.", "Некорректное значение. Повторите ввод");
                Lesson2Menu.PrintMenu();

                int choice = VC.FromMenu(Lesson2Menu);

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        TryNode();
                        onemoretime = true;
                        break;
                    case 2:
                        Console.Clear();
                        BinaryS.BinarySherch();
                        onemoretime = true;
                        break;
                    case 100:
                        Console.Clear();
                        onemoretime = false;
                        break;
                    default:
                        onemoretime = true;
                        break;
                }

            }
        }
        public static void TryNode()
        {
            ValidChoice VC = new ValidChoice();
            bool onemoretime = true;
            DBL_Node node;
            DBLListNode listNode = new DBLListNode();
            string[] menuRows =
            {
                "0 - Вывести общее количество элементов в двусвязном списке",
                "1 - Добавить элемент в двусвязный список по порядку",
                "2 - Добавить элемент в двусвязный список после указанного",
                "3 - Удалить элемент из двусвязного списка по индексу",
                "4 - Удалить указанный элемент из двусвязного списка",
                "5 - Вывод всех элементов списка",
                "6 - Выход к выбору задания урока №2"
            };
            Menu nodeListMenu = new Menu(menuRows, "Введите действие действия ", "Некорректное значение. Повторите ввод");
            while (onemoretime)
            {
                Console.WriteLine("---Работа с двусвязным списком---");
                nodeListMenu.PrintMenu();
                int choice = VC.FromMenu(nodeListMenu);
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("----------------");
                        Console.WriteLine("Элементов в списке:  -" + listNode.GetCount);
                        Console.WriteLine("----------------");
                        repit();
                        break;
                    case 1:
                        int numbToAdd = VC.FromRandom(0, 1000, "Введите целое число:", "Повторите ввод");
                        listNode.AddNode(numbToAdd);
                        repit();
                        break;
                    case 2:
                        int whatNode = VC.FromRandom(0, 1000, "Укажите число после кторого необходимо произвести вставку:", "Повторите ввод");
                        node = new DBL_Node(whatNode);
                        int numbToNode = VC.FromRandom(0, 1000, "Укажите число, кторое необходимо вставить:", "Повторите ввод");
                        listNode.AddNodeAfter(node, numbToNode);
                        repit();
                        break;
                    case 3:
                        int idexToDel = VC.FromRandom(0, 1000, "Укажите порядковый номер элемента для удаления", "Повторите ввод");
                        listNode.RemoveNode(idexToDel);
                        repit();
                        break;
                    case 4:
                        int whatNodeToDel = VC.FromRandom(0, 1000, "Укажите число которое необходимо удалить из списка", "Повторите ввод");
                        node = new DBL_Node(whatNodeToDel);
                        listNode.RemoveNode(node);
                        repit();
                        break;
                    case 5:
                        Console.WriteLine("----------------");
                        foreach (var v in listNode)
                        {
                            Console.WriteLine(v);
                        }
                        Console.WriteLine("----------------");
                        repit();
                        break;
                    case 6:
                        Console.Clear();
                        onemoretime = false;
                        break;
                    default:
                        break;
                }
            }
            void repit()
            {
                Console.WriteLine("Enter для продолжения");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    public class DBL_Node
    {
        public int Value { get; set; }
        public DBL_Node NextNode { get; set; }
        public DBL_Node PrevNode { get; set; }
        public DBL_Node(int n)
        {
            Value = n;
        }
    }
    public class DBLListNode : IEnumerable
    {
        public int GetCount = 0;
        DBL_Node first;
        DBL_Node last;

        public void AddNode(int n)
        {
            DBL_Node dNode = new DBL_Node(n);

            if (first == null)
            {
                first = dNode;
            }
            else
            {
                last.NextNode = dNode;
                dNode.PrevNode = last;
            }
            last = dNode;
            GetCount++;
        }
        public void AddNodeAfter(DBL_Node node, int value)
        {
            DBL_Node newNode = new DBL_Node(value);
            DBL_Node current = FindNode(node.Value);
            newNode.NextNode = current.NextNode;
            current.NextNode.PrevNode = newNode;
            current.NextNode = newNode;
            newNode.PrevNode = current;
            GetCount++;
        }
        public void AddInFirst(int n)
        {
            DBL_Node dNode = new DBL_Node(n);
            DBL_Node temp = first;

            if (first == null)
            {
                AddNode(n);

            }
            else
            {
                first = dNode;
                dNode.NextNode = temp;
                temp.PrevNode = dNode;
                GetCount++;
            }
        }
        public void RemoveNode(int index)
        {
            if (index > GetCount)
            {
                Console.WriteLine($"Невозможно удалить элемент списка с индексом {index}, так как в списке всего {GetCount} элементов");
                return;
            }
            else if (index < 1)
            {
                Console.WriteLine($"Индекс должен быть положительным не нулевым целым числом!");
                return;
            }
            DBL_Node current = first;
            for (int i = 1; i != index; i++)
            {
                current = current.NextNode;
            }

            if (current == first)
            {
                first = current.NextNode;
                first.PrevNode = null;
                GetCount--;
            }
            else if (current == last)
            {
                last = current.PrevNode;
                last.NextNode = null;
                GetCount--;
            }
            else
            {
                current.PrevNode.NextNode = current.NextNode;
                current.NextNode.PrevNode = current.PrevNode;
                current = null;
                GetCount--;
            }
        }
        public void RemoveNode(DBL_Node node)
        {
            DBL_Node current = FindNode(node.Value);
            current.NextNode.PrevNode = current.PrevNode;
            current.PrevNode.NextNode = current.NextNode;
            GetCount--;
        }
        public DBL_Node FindNode(int searchValue)
        {
            DBL_Node current = first;
            while (current.Value != searchValue)
            {
                current = current.NextNode;
            }
            return current;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            DBL_Node current = first;
            while (current != null)
            {
                yield return current.Value;
                current = current.NextNode;
            }
        }
    }

    class BinaryS
    {

        public static void BinarySherch()
        {
            ValidChoice VC = new ValidChoice();
            int[] arrayNums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.Write("Элементы массива:\t");
            foreach (int i in arrayNums)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.Write("номер элемента:\t\t");
            for (int i = 0; i <= arrayNums.Length - 1; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            int whatToFind = VC.FromRandom(arrayNums[0], arrayNums[arrayNums.Length - 1], "Введите искомый элемент", "Некорректный ввод повторите попытку");
            int expectedNumb = VC.FromRandom(0, arrayNums.Length + 10, "Ожидаемый порядковый номер", "Некорректный ввод повторите попытку");
            int result = BinaryFind(arrayNums, whatToFind);
            if (result == expectedNumb)
            {
                Console.WriteLine($"Тест пройдет, ожидаемое число-{expectedNumb} подтвердилось!");
            }
            else
            {
                Console.WriteLine($"Тест провален, ожидаемое число-{expectedNumb} не получено на выходе {result}!");
            }
            Console.WriteLine("Задание завершено. Для продолжения нажмите Enter");
            Console.ReadLine();
            Console.Clear();
        }
        public static int BinaryFind(int[] array, int volue)
        {
            int min = 0;
            int max = array.Length - 1;

            while (min <= max)
            {
                int midle = (min + max) / 2;

                if (volue == array[midle])
                {
                    return midle;
                }
                else if (volue < array[midle])
                {
                    max = midle - 1;

                }
                else
                {
                    min = midle + 1;
                }
            }
            return -1;
        }
    }
}




