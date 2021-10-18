using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    /// <summary>
    /// Узел для бинарного дерева
    /// </summary>
    public class BinaryTreeNode
    {
        public int Data { get; private set; }
        public BinaryTreeNode Right { get; set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Parent { get;  set; }
        public BinaryTreeNode(int data)
        {
            this.Data = data;
        }
        public BinaryTreeNode(int data, BinaryTreeNode parent)
        {
            this.Data = data;
            this.Parent = parent;
        }
        public override bool Equals(object obj)
        {
            var node = obj as BinaryTreeNode;
            if (node == null)
            {
                return false;
            }
            return node.Data == Data;
        }
    }
}
