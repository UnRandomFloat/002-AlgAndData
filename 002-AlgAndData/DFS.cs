using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    class DFS
    {

        Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();
        public void DeepFirstSearch(int whattoFind, BinaryTreeNode B_node)
        {
            if (B_node == null)
            {
                return;
            }
            stack.Push(B_node);
            while (stack.Count > 0)
            {
                BinaryTreeNode temp = stack.Pop();
                if (temp.Right != null)
                {
                    stack.Push(temp.Right);
                }
                if (temp.Left != null)
                {
                    stack.Push(temp.Left);
                }
                if (temp.Data == whattoFind)
                {
                    Console.WriteLine($"{temp.Data} -найдено!");
                }
                else
                {
                    Console.WriteLine(temp.Data);
                }
            }

        }
    }
}
