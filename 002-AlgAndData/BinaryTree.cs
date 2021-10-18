using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
   public class BinaryTree : ITree
    {
        public int totalNodes { get;  set; } = 0;
        public BinaryTreeNode Root { get;   set; }

        public void AddItem(int value)
        {
            if (Root == null)
            {
                Root = new BinaryTreeNode(value);
                Console.WriteLine($"Корень дерева -{value}- добавлен");
                totalNodes++;
            }
            else
            {
                BinaryTreeNode current = Root;
                do
                {

                    if (value > current.Data && current.Right == null)
                    {
                        current.Right = new BinaryTreeNode(value, current);
                        Console.WriteLine($"Значение -{value}- добавлено");
                        totalNodes++;
                        return;
                    }
                    else if (value > current.Data && current.Right != null)
                    {
                        current = current.Right;
                    }
                    else if (value <= current.Data && current.Left == null)
                    {
                        current.Left = new BinaryTreeNode(value, current);
                        Console.WriteLine($"Значение -{value}-добавлено");
                        totalNodes++;
                        return;
                    }
                    else if (value <= current.Data && current.Left != null)
                    {
                        current = current.Left;
                    }
                } while (true);
            }
        }

        public BinaryTreeNode GetNodeByValue(int value)
        {
            BinaryTreeNode current;
            if (Root == null)
            {
                Console.WriteLine("Дерево путое...");
                Console.WriteLine("совсем...");
                Console.WriteLine("Даже корня нет!");
                Console.WriteLine("Увы...");
                Console.WriteLine("Но жизнь продолжается!");
                return null;
            }
            else
            {
                current = Root;
                do
                {
                    if (current.Data == value)
                    {
                        return current;
                    }
                    else if (value<=current.Data && current.Left != null)
                    {
                        current = current.Left;
                    }
                    else if (value>current.Data  && current.Right != null)
                    {
                        current = current.Right;
                    }
                    else
                    {
                        Console.WriteLine("Узла с искомым значением не найдено");
                        return null;
                    }
                } while (true);
            }
        }

        public BinaryTreeNode GetRoot()
        {
            if (Root != null)
            {
                return Root;
            }
                      return null;
        }

        public void PrintTree()
        {
            PrintTree(Root);

        }
        public void PrintTree(BinaryTreeNode Root,  string space = "")
        {

            if (Root != null)
            {

                Console.WriteLine("{1} {0}", Root.Data, space);
                space = space.Replace('L', ' ');
                space = space.Replace('R', ' ');
                PrintTree(Root.Left, space + "    L");
                PrintTree(Root.Right, space + "    R");
            }
            else
            {
                Console.WriteLine("{0} пусто", space);
            }

        }

        public void RemoveItem(int n)
        {
            BinaryTreeNode current = GetNodeByValue(n);
            if (current == null)
            {
                return;
            }
            else if (current.Equals(Root))
            {
                current = current.Left;
                BinaryTreeNode temp = Root.Right;
                Root = current;
                Root.Parent = null;
                while (current.Right != null)
                {
                    current = current.Right;
                }
                current.Right = temp;
                Console.WriteLine($"Узел с числом {n} успешно удален!");
            }
            else
            {
                BinaryTreeNode currentLeft = current.Left;
                BinaryTreeNode currentRight = current.Right;
                if (currentLeft == null && currentRight == null)// удаление  листа
                {
                    if (current.Parent.Data <= current.Data)
                    {
                        current.Parent.Right = null;
                    }
                    else
                    {
                        current.Parent.Left = null;
                    }
                    Console.WriteLine($"Узел с числом {n} успешно удален!");
                }
                else if (currentLeft != null && currentRight == null)//удаление ветки с одним левым листом
                {
                    currentLeft.Parent = current.Parent;
                    if (current.Parent.Data <= current.Data)
                    {
                        current.Parent.Right = currentLeft;
                    }
                    else
                    {
                        current.Parent.Left = currentLeft;
                    }
                    Console.WriteLine($"Узел с числом {n} успешно удален!");
                }
                else if (currentLeft == null && currentRight != null)//удаление ветки с одним правым листом
                {
                    currentRight.Parent = current.Parent;
                    if (current.Parent.Data <= current.Data)
                    {
                        current.Parent.Right = currentRight;
                    }
                    else
                    {
                        current.Parent.Left = currentRight;
                    }
                    Console.WriteLine($"Узел с числом {n} успешно удален!");
                }
                else if (currentLeft != null && currentRight != null)//удаление ветки с двумя листами
                {

                    currentLeft.Parent = current.Parent;
                    if (current.Parent.Data <= current.Data)
                    {
                        current.Parent.Right = currentLeft;
                    }
                    else
                    {
                        current.Parent.Left = currentLeft;
                    }
                    while (currentLeft.Right != null)
                    {
                        currentLeft = currentLeft.Right;
                    }
                    currentLeft.Right = current.Right;
                    current.Right.Parent = currentLeft.Right;
                    Console.WriteLine($"Узел с числом {n} успешно удален!");

                }

                totalNodes--;
            }
        }

    }

    interface ITree
    {
        BinaryTreeNode GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        BinaryTreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }
}
